using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUDemo
{
    public class LRUCache<K, V>
    {
        private readonly int _maxCapacity = 0;
        private readonly Dictionary<K, Node<V, K>> _lruCache;
        private Node<V, K> _head = null;
        private Node<V, K> _tail = null;
        private const int _defaultCacheSize = 5;

        public LRUCache()
        {
            _maxCapacity = _defaultCacheSize;
            _lruCache = new Dictionary<K, Node<V, K>>();
        }

        public LRUCache(int cacheSize)
        {
            _maxCapacity = cacheSize;
            _lruCache = new Dictionary<K, Node<V, K>>();
        }

        public void Add(K key, V value)
        {
            if (_lruCache.ContainsKey(key))
            {
                MakeMostRecentlyUsed(_lruCache[key]);
            }

            if (_lruCache.Count >= _maxCapacity) RemoveLeastRecentlyUsed();

            Node<V, K> insertedNode = new Node<V, K>(value, key);

            if (_head == null)
            {
                _head = insertedNode;
                _tail = _head;
            }
            else MakeMostRecentlyUsed(insertedNode);

            _lruCache.Add(key, insertedNode);
        }

        public Node<V, K> GetItem(K key)
        {
            if (!_lruCache.ContainsKey(key)) return null;

            MakeMostRecentlyUsed(_lruCache[key]);

            return _lruCache[key];
        }

        public int Size()
        {
            return _lruCache.Count();
        }

        public string CacheFeed()
        {
            var headReference = _head;

            var items = new List<string>();

            while (headReference != null)
            {
                items.Add(string.Format("[{0}: {1}]", headReference.Key, headReference.Data));
                headReference = headReference.Next;
            }

            return string.Join(",", items);
        }

        private void RemoveLeastRecentlyUsed()
        {
            _lruCache.Remove(_tail.Key);
            _tail.Previous.Next = null;
            _tail = _tail.Previous;
        }

        private void MakeMostRecentlyUsed(Node<V, K> item)
        {

            if (item.Next == null && item.Previous == null)
            {
                item.Next = _head;
                _head.Previous = item;
                if (_head.Next == null) _tail = _head;
                _head = item;
            }

            else if (item.Next == null && item.Previous != null)
            {
                item.Previous.Next = null;
                _tail = item.Previous;
                item.Next = _head;
                _head.Previous = item;
                _head = item;
            }

            else if (item.Next != null && item.Previous != null)
            {
                item.Previous.Next = item.Next;
                item.Next.Previous = item.Previous;
                item.Next = _head;
                _head.Previous = item;
                _head = item;
            }

        }
    }
}
