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

            int[] M = new int[5] {1, 2, 4, 5,7};
            int k = Array.BinarySearch(M, 8);
            int index = ~k;
            int N = 1000000;
            int[] nums = new int[N];
            Random random = new Random(100000);
            for(int i = 0; i < N; i++)
            {
                nums[i] = random.Next();
            }

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
