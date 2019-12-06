using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algs
{
    public static class Util
    {
        public static void WriteTxtFile(int[] nums)
        {
            using (FileStream fs = new FileStream("ALotOfNums.txt", FileMode.Append))
            {
                using (StreamWriter wr = new StreamWriter(fs))
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        wr.WriteLine(nums[i]);
                    }
                    wr.Flush();
                }
            }
        }

        public static int[] ReadTxtFile(string path)
        {
            List<int> list = new List<int>();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        var st = sr.ReadLine();
                        int a = 0;
                        if (Int32.TryParse(st, out a))
                        {
                            list.Add(a);
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }
}
