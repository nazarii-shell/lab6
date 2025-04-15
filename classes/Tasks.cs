using System.Runtime.InteropServices.JavaScript;

namespace lab6.classes;

public class Tasks
{
    public static void Task1()
    {
        int N = 100;
        int size1 = (int)Math.Pow(N, 1);
        int size2 = (int)Math.Pow(N, 2);
        int size3 = (int)Math.Pow(N, 3);

        int[] data1 = fillNumbers(size1);
        int[] data2 = fillNumbers(size2);
        int[] data3 = fillNumbers(size3);


        double ms1 = GetAvgOfSort(10, data1, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size1}, MS = {ms1}");

        double ms2 = GetAvgOfSort(10, data2, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size2} MS = {ms2}");

        double ms3 = GetAvgOfSort(10, data3, InsertionSort);
        Console.WriteLine(ms3);
    }


    public static void Task2Binary()
    {
        int N = 100;
        int size1 = (int)Math.Pow(N, 1);
        int size2 = (int)Math.Pow(N, 2);
        int size3 = (int)Math.Pow(N, 3);

        int[] data1 = fillNumbers(size1);
        int[] data2 = fillNumbers(size2);
        int[] data3 = fillNumbers(size3);

        Array.Sort(data1);
        Array.Sort(data2);
        Array.Sort(data3);

        int index1 = new Random().Next(0, data1.Length);
        int toFind1 = data1[index1];
        double ms1 = GetAvgOfSearch(10, data1, toFind1, BinarySearch);
        Console.WriteLine($"Binary search, N = {size1}, MS = {ms1}");

        int index2 = new Random().Next(0, data2.Length);
        int toFind2 = data2[index2];
        double ms2 = GetAvgOfSearch(10, data2, toFind2, BinarySearch);
        Console.WriteLine($"Binary search, N = {size2} MS = {ms2}");

        int index3 = new Random().Next(0, data3.Length);
        int toFind3 = data3[index3];
        double ms3 = GetAvgOfSearch(10, data3, toFind3, BinarySearch);
        Console.WriteLine($"Binary search, N = {size3}, MS = {ms3}");
    }

    public static void Task2Interpolation()
    {
        int N = 100;
        int size1 = (int)Math.Pow(N, 1);
        int size2 = (int)Math.Pow(N, 2);
        int size3 = (int)Math.Pow(N, 3);

        int[] data1 = fillNumbers(size1);
        int[] data2 = fillNumbers(size2);
        int[] data3 = fillNumbers(size3);

        Array.Sort(data1);
        Array.Sort(data2);
        Array.Sort(data3);

        int index1 = new Random().Next(0, data1.Length);
        int toFind1 = data1[index1];
        double ms1 = GetAvgOfSearch(10, data1, toFind1, InterpolationSearch);
        Console.WriteLine($"InterpolationSearch, N = {size1}, MS = {ms1}");

        int index2 = new Random().Next(0, data2.Length);
        int toFind2 = data2[index2];
        double ms2 = GetAvgOfSearch(10, data2, toFind2, InterpolationSearch);
        Console.WriteLine($"InterpolationSearch, N = {size2} MS = {ms2}");

        int index3 = new Random().Next(0, data3.Length);
        int toFind3 = data3[index3];
        double ms3 = GetAvgOfSearch(10, data3, toFind3, InterpolationSearch);
        Console.WriteLine($"InterpolationSearch, N = {size3}, MS = {ms3}");
    }

    public static void Task3()
    {
        int N = 100;
        int size1 = (int)Math.Pow(N, 1);
        int size2 = (int)Math.Pow(N, 2);
        int size3 = (int)Math.Pow(N, 3);

        int[] data1 = fillNumbers(size1);
        int[] data2 = fillNumbers(size2);
        // int[] data3 = fillNumbers(size3);
        

        Console.WriteLine("Sort on random");
        double ms1 = GetAvgOfSort(10, data1, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size1}, MS = {ms1}");

        double ms2 = GetAvgOfSort(10, data2, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size2} MS = {ms2}");

        // double ms3 = GetAvgOfSort(10, data3, InsertionSort);
        // Console.WriteLine(ms3);
        
        Array.Sort(data1);
        Array.Sort(data2);
        
        Console.WriteLine("Sort on sorted");
        double ms4 = GetAvgOfSort(10, data1, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size1}, MS = {ms4}");

        double ms5 = GetAvgOfSort(10, data2, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size2} MS = {ms5}");

        Array.Reverse(data1);
        Array.Reverse(data2);
        
        Console.WriteLine("Sort on sorted reverse");
        double ms6 = GetAvgOfSort(10, data1, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size1}, MS = {ms6}");

        double ms7 = GetAvgOfSort(10, data2, InsertionSort);
        Console.WriteLine($"Insertion sort, N = {size2} MS = {ms7}");

        
       
    }

    public static int[] fillNumbers(int num)
    {
        int Min = 0;
        int Max = 1000;

        int[] newArr = new int[num];
        Random randNum = new Random();
        for (int i = 0; i < newArr.Length; i++)
        {
            newArr[i] = randNum.Next(Min, Max);
        }

        return newArr;
    }

    static void PrintArr<T>(T[] arr)
    {
        foreach (T element in arr)
        {
            Console.Write($"{element} \n");
        }
    }

    public static void InsertionSort(int[] data)
    {
        Algoritms.InsertionSort(data, data.Length);
    }

    public static void BinarySearch(int[] data, int toFind)
    {
        Algoritms.BinarySearch(data, toFind, 0, data.Length - 1);
    }

    public static void InterpolationSearch(int[] data, int toFind)
    {
        Algoritms.InterpolationSearch(data, toFind);
    }

    public static double GetAvgOfSort(int runFor, int[] data, Action<int[]> function)
    {
        double sum = 0;
        for (int i = 0; i < runFor; i++)
        {
            sum += TimerUtility.TimeSortExecution(function, data);
        }

        return sum / runFor;
    }

    public static double GetAvgOfSearch(int runFor, int[] data, int toFInd, Action<int[], int> function)
    {
        double sum = 0;
        for (int i = 0; i < runFor; i++)
        {
            sum += TimerUtility.TimeSortExecution(function, data, toFInd);
        }

        return sum / runFor;
    }
}