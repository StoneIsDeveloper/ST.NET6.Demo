// See https://aka.ms/new-console-template for more information
using AlgorithmsDemo;

Console.WriteLine("Hello, World!");

//var result = BasicAlgo.TestMerge();


//var a = new int[8] { 4, 2, 7, 1, 5, 3, 6, 2 };
var a = new int[8]   { 9, 8, 7, 6, 1, 4, 3, 2 };

int p = 1; 
int r = a.Length;

BasicAlgo.MergeSort(a,p,r);


Console.ReadKey();
