using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    /// <summary>
    /// 二叉查找树
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class BST<TKey,TValue> where TKey : IComparable
    {
        private Node root;//二叉查找树的根节点

        private class Node
        {
            public TKey key;//键
            public TValue value;//值
            public Node left;//指向左子树的链接
            public Node right;//指向右子树的链接
            public int N;//以该节点为根的子树的节点总数

            public Node(TKey key,TValue value,int n)
            {
                this.key = key;
                this.value = value;
                this.N = n;
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

        private int Size(Node node)
        {
            if (node == null) return 0;
            else return node.N;
        }

        public TValue Get(TKey key)
        {
            return Get(root, key);
        }

        /// <summary>
        /// 查找Key对应的值(递归实现)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private TValue Get1(Node x,TKey key)
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
        private TValue Get(Node x,TKey key)
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

        public void Put(TKey key,TValue value)
        {
            root = Put(root, key, value);
        }

        /// <summary>
        /// key,value插入根节点为x的二叉查找树
        /// </summary>
        /// <param name="x">要插入的根节点</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        private Node Put(Node x,TKey key,TValue value)
        {
            //根节点为null,创建新节点
            if (x == null) return new Node(key,value,1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                //插入的Key小于根节点,则插入其左子树
                x.left = Put(x.left, key, value);
            else if (cmp > 0)
                //插入的Key大于根节点,则插入右子树
                x.right = Put(x.right, key, value);
            else
                //插入的Key与根节点Key相等,更新根界面Key值
                x.value = value;
            //更新根节点节点数目
            x.N = Size(x.right) + Size(x.left) + 1;
            return x;
        }

        public TKey Max()
        {
            return root.key;
        }


        public TKey Min()
        {
            return Min(root).key;
        }

        /// <summary>
        /// 返回key最小的节点(递归实现)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private Node Min1(Node x)
        {
            if (x.left == null) return x;
            return Min(x.left);
        }

        /// <summary>
        /// 返回Key最小的节点,非递归实现
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private Node Min(Node x)
        {
            if (x == null){
                throw new ArgumentNullException("参数不能为null",nameof(x));
            }
            if (x.left == null) return x;
            Node tmp = x;
            while (tmp.left != null)
            {
                tmp = tmp.left;
            }
            return tmp;
        }

        public TKey Floor(TKey key)
        {
            var node = Floor(root, key);
            if (node == null) return default(TKey);
            return node.key;
        }

        private Node Floor(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.left, key);
            Node t = Floor(x.right, key);
            if (t != null) return t;
            else return x;

        }
        
    }
}
