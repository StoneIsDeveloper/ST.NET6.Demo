// See https://aka.ms/new-console-template for more information
using AlgorithmsDemo;

Console.WriteLine("Hello, World!");

{
    //var result = BasicAlgo.TestMerge();
    //var a = new int[8] { 4, 2, 7, 1, 5, 3, 6, 2 };
    var a = new int[8] { 9, 8, 7, 6, 1, 4, 3, 2 };

    int p = 1;
    int r = a.Length;

    BasicAlgo.MergeSort(a, p, r);

    var a2 = new int[8] { 9, 8, 7, 6, 1, 4, 3, 2 };
    int p2 = 1;
    int r2 = a.Length;

    BasicAlgo.MergeSortV2(a2, p2, r2);
}


{
    var b = new int[6] { 5, 2, 4, 6, 1, 3 };
    BasicAlgo.InsertionSort(b);

    var e = new int[6] { 5, 2, 4, 6, 1, 3 };
    BasicAlgo.InsertionSort(e);

}

{
    //矩阵

    //示例矩阵
    int[][] matrix1 = new int[][]
    {
        new int[] { 1, 2, 3 },
        new int[] { 4, 5, 6 },
        new int[] { 7, 8, 9 }
    };
    int[][] matrix2 = new int[][]
    {
      new int[] { 2, 3, 4 },
      new int[] { 5, 6, 7 },
      new int[] { 8, 9, 10 }
    };

    int[][] matrix3 = new int[][]
    {
          new int[] { 1 },
          new int[] { 1,2,},
          new int[] { 1,2,3 }
    };

    //  1  2  3
    //  4  5  6
    int[][] matrix4 = new int[][]
    {
        new int[] { 1, 2, 3 },
        new int[] { 4, 5, 6 }
    };
    // 1  2
    // 0  1
    // 2  3
    int[][] matrix5 = new int[][]
     {
              new int[] { 1, 2 },
              new int[] { 0, 1 },
              new int[] { 2, 2 }
     };
    int[][] matrix6 = new int[][]
    {
              new int[] { 1, 2,1 },
              new int[] { 0, 1,1 },
              new int[] { 2, 2,1 }
    };


  //  BasicMatrix.ShowMatrixV2(matrix4);
    //BasicMatrix.ShowMatrixV2(matrix5);
  //  BasicMatrix.ShowMatrixV2(matrix6);

    // var result1 = BasicMatrix.AddMatrix(matrix1, matrix2);

   // var result2 = BasicMatrix.MultMatrix(matrix4, matrix6);
  //  BasicMatrix.ShowMatrixV2(result2);

    //二维数组
    // 1  2  3
    // 4  5  6
    const int rowLength = 2;
    const  int columnLength = 3;
    int[,] ma = new int[rowLength, columnLength] { { 1,2,3},{ 4,5,6} };

  //  BasicMatrix.ShowMatrix(ma);

}

#region  Strassen Multiply 矩阵乘法
{
    int[][] matrixa = new int[][]
    {
        new int[] { 2, 3 },
        new int[] { 4, 6 },

    };
    int[][] matrixb = new int[][]
    {
      new int[] { 7, 3 },
      new int[] { 5, 6 }
    };

    int[][] matrixc = new int[][]
    {
        new int[] { 2, 3,5,4 },
        new int[] { 4, 6,7,8 },
        new int[] { 5, 1,7,7 },
        new int[] { 8, 4,6,2 },
    };

    int[][] matrixd = new int[][]
    {
      new int[] { 5, 2, 1, 7},
      new int[] { 1, 3, 9, 8},
      new int[] { 9, 3, 4, 5},
      new int[] { 9, 2, 0, 1},
    };


    int[][] result1 = BasicMatrix.MultMatrix(matrixa, matrixb);
    int[][] result2 = BasicMatrix.StrassenMultiply(matrixa, matrixb);
    BasicMatrix.ShowMatrixV2(result1);
    BasicMatrix.ShowMatrixV2(result2);

    int[][] result3 = BasicMatrix.MultMatrix(matrixc, matrixd);
    int[][] result4 = BasicMatrix.StrassenMultiply(matrixc, matrixd);

    BasicMatrix.ShowMatrixV2(result3);
    BasicMatrix.ShowMatrixV2(result4);

}
#endregion



Console.ReadKey();
