﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUDemo
{
    public class Node<D, K>
    {
        public D Data { get; private set; }
        public K Key { get; private set; }
        public Node<D, K> Previous { get; set; }
        public Node<D, K> Next { get; set; }

        public Node(D data, K key)
        {
            Data = data;
            Key = key;
        }
    }
}
