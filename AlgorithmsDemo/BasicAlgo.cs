using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDemo
{
    public class BasicAlgo
    {

        #region 分治算法 - 归并排序
        public void TestMerge()
        {
           var a = new int[8] { 2, 4, 5, 7, 1, 2, 3, 6 };
            var p = 1;
            var q = 4;
            var r = 8;
           var result =  Merge(a, p, q, r);
        }

        public int[] Merge(int[] a,int p1,int p2,int r)
        {
            var result = new int[8];
            int n1 = p2 - p1 + 1; //4
            int n2 = r - p2;  // 4
            int[] left = new int[n1+1];   //2, 4, 5, 7
            int[] rigth = new int[n2+1];  //1, 2, 3, 6
            for (int i = 0; i < n1; i++)
            {
                left[i] = a[p1+i-1];
            }
            for (int j = 0; j < n2; j++)
            {
                rigth[j] = a[n2 + j];
            }
            left[n1 + 1] = int.MaxValue;
            rigth[n2 + 1] = int.MaxValue;

            int ii = 0;
            int jj = 0;

            for (int k = 0; k < r; k++)
            {
                if(left[ii] <= rigth[jj])
                {
                    a[k] = left[ii];
                    ii++;
                }
                else
                {
                    a[k] = rigth[jj];
                    jj++;
                }
            }

            return a;

        }
        #endregion
    }
}
