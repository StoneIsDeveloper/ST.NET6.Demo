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
}


{
    var b = new int[6] { 5, 2, 4, 6, 1, 3 };
    BasicAlgo.InsertionSort(b);

}




Console.ReadKey();
