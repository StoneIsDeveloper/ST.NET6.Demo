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

        #region Strassen Matrix Algorithm
        public static int[][] StrassenMultiply(int[][] matrix1, int[][] matrix2)
        {
            //合法性检查 
            if (!IsMatrix(matrix1) || !IsMatrix(matrix2))
            {
                throw new Exception("input is not matrix");
            }

            int n = matrix1.GetLength(0);
            int[][] result = CreateEmptyMatrix(n);

            if (n == 1)
            {
                result[0][0] = matrix1[0][0] * matrix2[0][0];
                return result;
            }


            // Step 1: Dividing Matrix into parts
            // by storing sub-parts to variables
            int[][] A11 = CreateEmptyMatrix(n/2);
            int[][] A12 = CreateEmptyMatrix(n/2);
            int[][] A21 = CreateEmptyMatrix(n/2);
            int[][] A22 = CreateEmptyMatrix(n/2);
            int[][] B11 = CreateEmptyMatrix(n/2);
            int[][] B12 = CreateEmptyMatrix(n/2);
            int[][] B21 = CreateEmptyMatrix(n/2);
            int[][] B22 = CreateEmptyMatrix(n/2);

            // Step 2: Dividing matrix A into 4 halves
            Split(matrix1, A11, 0, 0);
            Split(matrix1, A12, 0, n/2);
            Split(matrix1, A21, n/2, 0);
            Split(matrix1, A22, n/2, n/2);


            // Step 2: Dividing matrix B into 4 halves
            Split(matrix2, B11, 0, 0);
            Split(matrix2, B12, 0, n / 2);
            Split(matrix2, B21, n / 2, 0);
            Split(matrix2, B22, n / 2, n / 2);

            //  a = A11
            // 

            // Using Formulas as described in algorithm
            // M1:=(A1+A3)X(B1+B2)
            int[][] M1 = StrassenMultiply(Add(A11, A22), Add(B11, B22));

            // M2:=(A2-A4)X(B3+B4)
            int[][] M2 = StrassenMultiply(Add(A11, A22), Add(B11, B22));

            // M3:=(A1-A4)X(B1+A4)
            int[][] M3 = StrassenMultiply(Add(A11, A22), Add(B11, B22));

            // M4:=A1X(B2-B4)
            int[][] M4 = StrassenMultiply(A22, Sub(B21, B11));

            // M5:=(A3+A4)X(B1)
            int[][] M5 = StrassenMultiply(Add(A11, A12), B22);

            // M6:=(A1+A2)X(B4)
            int[][] M6 = StrassenMultiply(Sub(A21, A11), Add(B11, B12));

            // M7:=A4X(B3-B1)
            int[][] M7 = StrassenMultiply(Sub(A12, A22), Add(B21, B22));

            // P:=M2XM3-M6-M7
            int[][] C11 = Add(Sub(Add(M1, M4), M5), M7);

            // Q:=M4+M6
            int[][] C12 = Add(M3, M5);

            // R:=M5+M7
            int[][] C21 = Add(M2, M4);

            // S:=M1-M3-M4-M5
            int[][] C22 = Add(Sub(Add(M1, M3), M2), M6);

            // Step 3: Join 4 halves into one result matrix
            Join(C11, result, 0, 0);
            Join(C12, result, 0, n / 2);
            Join(C21, result, n / 2, 0);
            Join(C22, result, n / 2, n / 2);


            return result;
        }

        private static int[][] CreateEmptyMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            return result;
        }

        /// <summary>
        ///  Function to subtract two matrices
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int[][] Sub(int[][] a, int[][] b)
        {
            int n = a.GetLength(0);

            int[][] c = CreateEmptyMatrix(a.GetLength(0));

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    c[i][j] = a[i][j] + b[i][j];
            }

            return c;
        }

        /// <summary>
        /// Function to add two matrices
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int[][] Add(int[][] a, int[][] b)
        {
            int n = a.GetLength(0);

            int[][] c = CreateEmptyMatrix(a.GetLength(0));

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    c[i][j] = a[i][j] + b[i][j];
            }

            return c;
        }

        private static void Split(int[][] matrix, int[][]subMatrix, int iB, int jB)
        {
            int i2 = iB;
            for (int i1 = 0; i1 < subMatrix.GetLength(0); i1++)
            {
                int j2 = jB;
                for (int j1 = 0; j1 < subMatrix.GetLength(0); j1++)
                {
                    subMatrix[i1][j1] = matrix[i2][j2];     
                    j2++;
                }
                i2++;
            }
        }

        /// <summary>
        /// Function to join child matrices  into (to) parent matrix
        /// </summary>
        /// <param name="childMatrix"></param>
        /// <param name="matrix"></param>
        /// <param name="iB"></param>
        /// <param name="jB"></param>
        private static void Join(int[][] childMatrix,int[][] matrix, int iB, int jB)
        {
            int i2 = iB;
            for (int i1 = 0; i1 < childMatrix.GetLength(0); i1++)
            {
                int j2 = jB;
                for (int j1 = 0; j1 < childMatrix.GetLength(0); j1++)
                {
                    matrix[i1][j1] = childMatrix[i2][j2];
                    j2++;
                }
                i2++;
            }
        } 

        #endregion

    }


    public class Matrix
    {
        public int I { get; set; }
        public int J { get; set; }
        public int[,] mas { get; set; }
        public int n { get; set; }

        public Matrix(int size)
        {
            mas = new int[size, size];
            I = 0;
            J = 0; 
            n = size;
        }
        
        public Matrix(int[,] matrix, int i, int j, int m)
        {
            I = i;
            J = j;
            n = m;
            mas = matrix;
        }

        public Matrix(int[,] matrix)
        {
            I = 0;
            J = 0;
            mas = matrix;
            n = matrix.GetLength(0);
        }

        public Matrix GetLeftTopSubMatrix()
        {
            return new Matrix(mas, I, J, n / 2);
        }

        public Matrix GetLeftDownSubMatrix()
        {
            return new Matrix(mas, I + n / 2, J, n / 2);
        }

        public Matrix GetRightTopMatrix()
        {
            return new Matrix(mas, I, J + n / 2, n / 2);
        }

        public Matrix GetRightDownMatrix()
        {
            return new Matrix(mas, I + n / 2, J + n / 2, n / 2);
        }






    }


}
