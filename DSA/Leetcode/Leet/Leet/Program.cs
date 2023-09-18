using System;

public class Kata
{
    

    public static void Main()
    {
        Func<int, bool> isEven = (value) => value % 2 == 0;
        DropWhile(new int[] { 2, 4, 6, 8, 1, 2, 5, 4, 3, 2 }, isEven);
    }
    public static int[] DropWhile(int[] arr, Func<int, bool> pred)
    {
        int[] someArr = new int[0];
        for (int i = 0; i < arr.Length; i++)
        {
 LearnSystemIO           if (!pred(arr[i]))
            {
                Array.Resize(ref someArr, arr.Length - i);
                for (int j = 0; j < arr.Length - i; j++)
                {
                    someArr[j] = arr[i + j];
                }
                break;
            }
        }
        return someArr;
    }
}