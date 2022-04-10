using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDemo
{
    public class BasicMatrix
    {


        /// <summary>
        /// 判断一个二维数组是否为矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool IsMatrix(int[][] matrix)
        {
            //空矩阵是矩阵
            if (matrix.Length < 1) return true;

            //不同行列数如果不同，则不是矩阵
            int count = matrix[0].Length;
            for(int i=1; i< matrix.Length; i++)
            {
                if(matrix[i].Length != count)
                {
                    return false;
                }
            }

            //各行列数相等，则是矩阵
            return true;
        }

        public static int[] MatrixCR(int[][] matrix)
        {
            if (!IsMatrix(matrix))
            {
                throw new Exception("input is not a matrix");
            }

            if(IsMatrix(matrix) || matrix.Length == 0)
            {
                return new int[2] { 0, 0 };
            }

            return new int[2] { matrix.Length, matrix[0].Length };

        }

        /// <summary> 
        /// 矩阵加法
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int[][] AddMatrix(int[][] matrix1,int[][]matrix2)
        {
            //矩阵1和矩阵2须为同型矩阵
            if(!IsMatrix(matrix1) || !IsMatrix(matrix2))
            {
                throw new Exception("不同型矩阵无法进行加法运算");
            }

            //create an empty matrix
            int[][] result = new int[matrix1.Length][];
            for(int i=0; i< result.Length; i++)
            {
                result[i] = new int[matrix1[i].Length];
            }

            //把矩阵各元素相加
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }

            return result;

        }


        public static int[][] MultMatrix(int[][] matrix1, int[][] matrix2)
        {
            //合法性检查 
            if(!IsMatrix(matrix1) || !IsMatrix(matrix2))
            {
                throw new Exception("input is not matrix");
            }

            // var rowLength = matrix1.GetLength(0);
            var columnLength = matrix1[0].Length;
            var rowLength = matrix2.Length;
            
            if(rowLength != columnLength)
            {
                throw new Exception("matrix2 rows is different with matrix2 columns");
            }

            //  matrix1是m*n矩阵，  2*3
            //  matrix2是n*p矩阵，       3*2
            //  则result是m*p矩阵   
            int m = matrix1.Length, n = matrix2.Length, p = matrix2[0].Length;
            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[p];
            }

            //矩阵乘法
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    //对乘加法则
                    for (int k = 0; k < n; k++)
                    {
                        result[i][j] += matrix1[i][k] * matrix2[k][j];
                    }
                }
            }


            return result;            
        }

        public static void ShowMatrixV2(int[][] matrix)
        {
            Console.WriteLine("------不规则二维数组的输出：开始-------------------");
            var rowLength = matrix.GetLength(0);
            if (rowLength < 1) return;

            for (int i = 0; i < rowLength; i++)
            {
                var columnLength = matrix[i].Length;
                int[] arr = new int[columnLength];

                for (int j = 0; j < columnLength; j++)
                {
                    arr[j] = matrix[i][j];
                }
                Console.WriteLine(string.Join(',', arr));

            }

            Console.WriteLine("------规则二维数组的输出：完成-------------------");
        }

        public static void ShowMatrix(int[,] matrix)
        {
            var rowLength = matrix.GetLength(0);         //一维长度
            var columnLength = matrix.GetLength(1);     //二维长度

            Console.WriteLine("------规则二维数组的输出：开始-------------------");
            for (int i = 0; i < rowLength; i++)
            {
                int[] arr = new int[columnLength];
                for (int j = 0; j < columnLength; j++)
                {
                    //Console.WriteLine($@"a[{i},{j}]:{ma[i, j]}");
                    arr[j] = matrix[i, j];
                }
                Console.WriteLine(string.Join(',', arr));
            }
            Console.WriteLine("------规则二维数组的输出：完成-------------------");


        }


    }
}
