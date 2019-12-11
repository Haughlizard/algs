using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgsUnitTest
{
    [TestClass]
    public class SortUnitTest
    {
        [TestMethod]
        public void BubbleSort_Test()
        {
            int[] nums = new int[10] { 3, 4, 6, 78, 8, 5, 90, 12, 56, 44 };
            Sort.Sort.BubbleSort(nums);

            int[] except = new int[10] { 3, 4, 5, 6, 8, 12, 44, 56, 78, 90 };
            CollectionAssert.AreEqual(except, nums);
        }

        [TestMethod]
        public void SelectionSort_Test()
        {
            int[] nums = new int[10] { 3, 4, 6, 78, 8, 5, 90, 12, 56, 44 };
            Sort.Sort.SelectionSort(nums);

            int[] except = new int[10] { 3, 4, 5, 6, 8, 12, 44, 56, 78, 90 };
            CollectionAssert.AreEqual(except, nums);
        }

        [TestMethod]
        public void InsertionSort_Test()
        {
            int[] nums = new int[10] { 3, 4, 6, 78, 8, 5, 90, 12, 56, 44 };
            Sort.Sort.InsertionSort(nums);

            int[] except = new int[10] { 3, 4, 5, 6, 8, 12, 44, 56, 78, 90 };
            CollectionAssert.AreEqual(except, nums);
        }

        [TestMethod]
        public void QuickSort_Test()
        {
            int[] nums = new int[10] { 3, 4, 6, 78, 8, 5, 90, 12, 56, 44 };
            Sort.Sort.QuickSort(nums, 0, nums.Length-1);

            int[] except = new int[10] { 3, 4, 5, 6, 8, 12, 44, 56, 78, 90 };
            CollectionAssert.AreEqual(except, nums);
        }

        [TestMethod]
        public void MergeSort_Test()
        {
            int[] nums = new int[10] { 3, 4, 6, 78, 8, 5, 90, 12, 56, 44 };
            Sort.Sort.MergeSort(nums,0,nums.Length-1);

            int[] except = new int[10] { 3, 4, 5, 6, 8, 12, 44, 56, 78, 90 };
            CollectionAssert.AreEqual(except, nums);
        }
    }
}
