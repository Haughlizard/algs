using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] K = new int[10] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 };

            int[] M = new int[5] {1, 2, 4, 5, 7};

            //int k = Array.BinarySearch(M, 8);
            //int index = ~k;
            Array.Array.Merge(K, 5, M, 5);
            int N = 1000000;
            int[] nums = new int[N];
            Random random = new Random(100);
            for(int i = 0; i < N; i++)
            {
                nums[i] = random.Next();
            }

            Sort.Sort.InsertionSort(nums);

            BST<int, int> bst = new BST<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                bst.Put(nums[i],i);
            }
            var result = bst.Min();
            var min = nums.Min();
            Console.WriteLine(result);
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
