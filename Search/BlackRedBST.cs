using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class BlackRedBST<TKey,TValue> where TKey : IComparable
    {
        private const bool RED = true;
        private const bool BLACK = false;

        private Node root;
        private class Node
        {
            public TKey key { get; set; }
            public TValue value { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
            public int N { get; set; }
            public bool color { get; set; }

            public Node(TKey key,TValue value,int n,bool color)
            {
                this.key = key;
                this.value = value;
                this.N = n;
                this.color = color;
            }
        }

        /// <summary>
        /// 返回二叉查找树的总节点数
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return Size(root);
        }

        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Get(TKey key)
        {
            return Get(root, key);
        }

        /// <summary>
        /// 向红黑树插入键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(TKey key,TValue value)
        {
            root = Put(root, key, value);
            root.color = BLACK;
        }

        /// <summary>
        /// 向节点h插入键值对
        /// </summary>
        /// <param name="h"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Node Put(Node h,TKey key,TValue value)
        {
            if (h == null)
                return new Node(key, value, 1, BLACK);
            int cmp = key.CompareTo(h.key);
            if (cmp < 0) Put(h.left, key, value);
            else if (cmp > 0) Put(h.right, key, value);
            else h.value = value;

            if (IsRed(h.left) && !IsRed(h.right)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) FlipColor(h);

            h.N = Size(h.left) + Size(h.right) + 1;
            return h;
        }

        /// <summary>
        /// 查找Key对应的值(递归实现)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private TValue Get1(Node x, TKey key)
        {
            //在以节点x为根节点的二叉查找树中查询key对应的值
            if (x == null)
                return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                //Key值小于节点x,在其左子树中查找
                return Get(x.left, key);
            else if (cmp > 0)
                //Key值大于节点x,在其右子树中查找
                return Get(x.right, key);
            else
                //Key值等于节点x,命中,返回值
                return x.value;
        }

        /// <summary>
        /// 查找Key对应的值(非递归实现)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private TValue Get(Node x, TKey key)
        {
            if (x == null) return default(TValue);
            Node temp = x;
            while (temp != null)
            {
                int cmp = key.CompareTo(temp.key);
                if (cmp < 0)
                    temp = temp.left;
                else if (cmp > 0)
                    temp = temp.right;
                else
                    return temp.value;
            }
            return default(TValue);
        }

        /// <summary>
        /// 获取节点node及其子树的节点总数
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Size(Node node)
        {
            if (node == null) return 0;
            else return node.N;
        }

        /// <summary>
        /// 判断某个节点是否为红节点
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool IsRed(Node x)
        {
            if (x == null) return false;
            return x.color == RED;
        }

        /// <summary>
        /// 左旋转
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = Size(h.left) + Size(h.right) + 1;
            return x;
        }

        /// <summary>
        /// 右旋转
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = Size(h.right) + Size(h.left) + 1;
            return x;
        }

        private void FlipColor(Node h)
        {
            h.color = RED;
            h.right.color = BLACK;
            h.left.color = BLACK;
        }

    }
}
