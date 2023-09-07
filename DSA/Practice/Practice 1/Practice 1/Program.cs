using System;

Console.WriteLine(RecurseFib(8));
Console.WriteLine(Factorial(10));
static int RecurseFib(int input)
{
    if (input == 0) return 0;
    if (input == 1) return 1;

    return (RecurseFib(input-1) + RecurseFib(input-2));
}


static int Factorial(int num)
{
    if (num == 0) return 1;

    return num * Factorial(num - 1);
}





//foreach (var item in FibYieldRecursion(100))
//{
//    Console.WriteLine(item);
//    if (item < 0) break;
//}
static IEnumerable<long> FibYieldRecursion(long fibLength)
{
    long[] fibArr = new long[fibLength + 1];
    fibArr[0] = 0;
    fibArr[1] = 1;
    for (long i = 2; i <= fibLength; i++)
    {
        fibArr[i] = fibArr[i - 1] + fibArr[i - 2];
        yield return fibArr[i];
    }
}


//for loop. i = length. i > 0. i--..
//swap method. swap current and next index (i+1).
//
int[] numArr = { 55, 66, 51, 1000, 84, 1, 66, 0, 5874, 750 };
Console.WriteLine(string.Join(",", BubbleSort(numArr)));
static int[] BubbleSort(int[] numArr)
{
    for(int i = numArr.Length - 1; i > 0; i--)
    {
        for (int a = 0; a < numArr.Length - 1; a++)
        {
            //swap
            if (numArr[a] > numArr[a + 1])
            {
                (numArr[a], numArr[a + 1]) = (numArr[a + 1], numArr[a]); 
            }
        }
    }
    return numArr;
}


int[] arr = { 55, 66, 51, 1000, 84, 1, 66, 0, 5874, 750 };
Sort(arr);
Console.WriteLine(string.Join(",", arr));

static void Sort(int[] arr)
{
    int n = arr.Length;
    bool swapped;
    do
    {
        swapped = false;
        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                // Swap arr[i-1] and arr[i]
                (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                swapped = true;
            }
        }
    } while (swapped);
}
