using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var lruCache = new LRUCache<int, int>();

            Console.WriteLine(lruCache.Size());

            lruCache.Add(0, 11);
            lruCache.Add(1, 22);
            lruCache.Add(2, 33);
            lruCache.Add(3, 44);
            lruCache.Add(4, 55);

            Console.WriteLine();
            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());

            lruCache.GetItem(0);
            lruCache.GetItem(1);
            lruCache.GetItem(2);

            Console.WriteLine();
            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());

            lruCache.Add(5, 66);
            lruCache.Add(6, 77);
            lruCache.Add(7, 88);
            lruCache.Add(8, 99);
            lruCache.Add(9, 111);

            Console.WriteLine();
            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());

            lruCache.GetItem(8);
            lruCache.GetItem(5);
            lruCache.GetItem(10);

            Console.WriteLine();
            Console.WriteLine(lruCache.CacheFeed());

            lruCache.Add(10, 222);
            Console.WriteLine();
            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());

            Console.ReadLine();
        }
    }
}
