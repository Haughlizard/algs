using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class Sort
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="nums"></param>
        public static void BubbleSort(int[] nums)
        {
            for(int i = 0; i < nums.Length-1; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        Swap(nums, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="nums"></param>
        public static void SelectionSort(int[] nums)
        {
            for(int i = 0; i < nums.Length - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[min])
                        min = j;
                }
                Swap(nums, i, min);
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="nums"></param>
        public static void InsertionSort(int[] nums)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for(int i = 0; i < nums.Length; i++)
            {
                int j = i-1;
                int t = nums[i];
                for (; j >= 0; j--)
                {
                    if (nums[j] > t)
                    {
                        nums[j + 1] = nums[j];
                    }
                    else
                    {
                        break;
                    }
                }
                nums[j + 1] = t;
            }
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        public static void QuickSort(int[] nums,int left,int right)
        {
            while (left < right)
            {
                int i = left;
                int j = right;
                int middle = (left + right) / 2;
                SwapIfGreater(nums, left, middle);
                SwapIfGreater(nums, left, right);
                SwapIfGreater(nums, middle, right);
                int x = nums[middle];
                while (i <= j)
                {
                    while (nums[i] < x) i++;
                    while (nums[j] > x) j--;
                    if (i > j) break;
                    if (i < j)
                    {
                        Swap(nums, i, j);
                    }
                    i++;
                    j--;
                }

                if (j - left <= right - i)
                {
                    if (left < j) QuickSort(nums, left, j);
                    left = i;
                }else
                {
                    if (right > i) QuickSort(nums, i, right);
                    right = j;
                }
            }
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="nums"></param>
        private static int[] aux;
        public static void MergeSort(int[] nums)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            
            aux = new int[nums.Length];
            MergeSort(nums, 0, nums.Length - 1);
            sw.Stop();
            var t = sw.ElapsedMilliseconds;
        }
        public static void MergeSort(int[] nums,int left,int right)
        {
            if (right <= left) return;
            int middle = left + (right - left) / 2;
            MergeSort(nums, left, middle);
            MergeSort(nums, middle + 1, right);
            Merge(nums, left, middle, right);
            
        }

        private static void Merge(int[] nums,int left, int mid,int right)
        {
            int i = left;
            int j = mid + 1;
            for(int k = left; k <= right; k++){
                aux[k] = nums[k];
            }
            for(int k = left; k <= right; k++){
                if (i > mid) nums[k] = aux[j++];
                else if (j > right) nums[k] = aux[i++];
                else if (aux[j] < aux[i]) nums[k] = aux[j++];
                else nums[k] = aux[i++];
            }
        }

        

        private static void Swap(int[] nums, int i, int j)
        {
            var t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }

        private static void SwapIfGreater(int[] nums,int i,int j)
        {
            if (nums[i] > nums[j])
            {
                var t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
            }
        } 
    }
}
