using CodilityTest;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var number1 = 1025;
var str = Convert.ToString(number1, 2);
Console.WriteLine(number1);

Console.WriteLine(str);

// 1. Find Max gap in Binary
var maxGap =CenterUility.FindMaxBinaryGap(number1);


// 2.
int[] a= new int[5] { 3, 8, 9, 7, 6 };

var b =CenterUility.CyclicRotation(a,5);


var jmp =CenterUility.FrogJmp(10,85,30);

int[] c = new int[5] { 6, 4, 1, 2,3 };
var missE = CenterUility.PermMissingElem(c);


int[] d = new int[2] { 1, 200 };
//var miniGap = CenterUility.TapeEquilibrium(d);

var miniGap = CenterUility.TapeEquilibriumV2(d);

int[] e = new int[4] { 1,2,1,2};

var result =CenterUility.MaxCounters(1,e);

Console.ReadKey();


