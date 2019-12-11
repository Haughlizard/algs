using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class Array
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] tmp = new int[m];
            for(int i = 0; i < m; i++)
            {
                tmp[i] = nums1[i];
            }
            int j = 0;
            int k = 0;
            for(int i = 0; i < m + n; i++)
            {
                if(j >= n&&j<m)
                {
                    nums1[i] = tmp[j];
                    j++;
                }
                else if (tmp[j] <= nums2[k]) {
                    nums1[i] = tmp[j];
                    j++;
                }else
                {
                    nums1[i] = nums2[k];
                    k++;
                }
                
            }
        } 
    }
}
