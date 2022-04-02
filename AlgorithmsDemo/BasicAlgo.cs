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
        public static int[] TestMerge()
        {
            var a = new int[8] { 4, 2, 7, 1, 6, 3, 5, 2 };
            var p = 1;
            var q = 4;
            var r = 8;
            return Merge(a, p, q, r);
        }

        public static void MergeSort(int[] a, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;  // 8/2 =4  9/2 = 4

                // 递归式 分解 
                MergeSort(a, p, q);  // left
                MergeSort(a, q + 1, r); //right

                //自低向上 归并排序
                Merge(a, p, q, r);



            }
        }

        public static int[] Merge(int[] a, int p1, int p2, int r)
        {
            var result = new int[8];
            int n1 = p2 - p1 + 1; //4
            int n2 = r - p2;  // 4
            int[] left = new int[n1 + 1];   //4, 2, 7, 5
            int[] right = new int[n2 + 1];  //1, 3, 6, 2 

            for (int i = 0; i < n1; i++)
            {
                left[i] = a[p1 + i - 1];
            }
            for (int j = 0; j < n2; j++)
            {
                right[j] = a[p2 + j];
            }

            left[n1] = int.MaxValue;
            right[n2] = int.MaxValue;

            int ii = 0;
            int jj = 0;

            for (int k = p1; k <= r; k++)
            {

                if (left[ii] <= right[jj])
                {
                    a[k-1] = left[ii];
                    ii++;
                }
                else
                {
                    a[k-1] = right[jj];
                    jj++;
                }


            }

            return a;

        }


        public static void MergeSortV2(int[] a, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;  // 8/2 =4  9/2 = 4

                // 递归式 分解 
                MergeSortV2(a, p, q);  // left
                MergeSortV2(a, q + 1, r); //right

                //自低向上 归并排序
                MergeV2(a, p, q, r);
            }
        }
        /// <summary>
        /// 不适用哨兵
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static int[] MergeV2(int[] a, int p1, int p2, int r)
        {
            var result = new int[8];
            int n1 = p2 - p1 + 1; //4
            int n2 = r - p2;  // 4
            int[] left = new int[n1];   //4, 2, 7, 5
            int[] right = new int[n2];  //1, 3, 6, 2 

            for (int i = 0; i < n1; i++)
            {
                left[i] = a[p1 + i - 1];
            }
            for (int j = 0; j < n2; j++)
            {
                right[j] = a[p2 + j];
            }


            int ii = 0;
            int jj = 0;

            //如果一个数组已全部复制回A, 就把另一个数组剩余的元素全部复制回A

            for (int k = p1; k <= r; k++)
            {
                if(ii == left.Length && jj < right.Length)// left is done, then clone right
                {
                    a[k - 1] = right[jj];
                    jj++;
                }
                if (jj == right.Length && ii< left.Length )// right is done, then clone left
                {
                    a[k - 1] = left[ii];
                    ii++;
                }
   
                if(ii< left.Length && jj< right.Length)
                {
                    if (left[ii] <= right[jj])
                    {
                        a[k - 1] = left[ii];
                        ii++;  // 0 1 2 3
                    }
                    else
                    {
                        a[k - 1] = right[jj];
                        jj++; // 0 1 2 3
                    }
                }              

            }

            return a;

        }
        #endregion

        #region 插入排序
        public static void InsertionSort(int[] a)
        {
            for (int j = 1; j < a.Length; j++)
            {
                int key = a[j];

                int i = j - 1;                
                while (i >= 0 && a[i] > key)
                {
                    a[i + 1] = a[i];
                    i = i - 1;
                }

                a[i + 1] = key;
            }
        }
        #endregion
    }
}
