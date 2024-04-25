



using recursiveProgrammingSample.UnivercitySample.subtractionHumanAproach;

int[,] array = new int[2,5]{  { 1, 2, 3, 4, 5 } , //first number
                            { 0, 0, 7, 8, 9 }   //secound number
                          }; //true result is 1 1 5 5 6

/////recursive implement test
IsubtractionHumanAproach objRecursive = new subtractionRecursive();

var resultRecursive = objRecursive.Calculate(array);

Console.WriteLine("\nrecursive output: ");

foreach (var item in resultRecursive)
{
    Console.Write(item + " ");
}

/////simple implement test
IsubtractionHumanAproach objsimple = new subtractionRecursive();
var resultSimple = objsimple.Calculate(array);
Console.WriteLine("\nSimple output: ");

foreach (var item in resultSimple)
{
    Console.Write(item + " ");
}