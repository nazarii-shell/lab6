namespace lab6.classes;

public class Algoritms
{
    public static int[] InsertionSort(int[] array, int length)
    {
        for (int i = 1; i < length; i++)
        {
            var key = array[i];
            var flag = 0;
            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (key < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                    array[j + 1] = key;
                }
                else flag = 1;
            }
        }
        return array;
    }
    
    public static int BinarySearch(int[] arr, int target, int left, int right)
    {
        if (left > right)
            return -1; // Base case: not found

        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
            return mid;
        else if (arr[mid] < target)
            return BinarySearch(arr, target, mid + 1, right);
        else
            return BinarySearch(arr, target, left, mid - 1);
    }
    
    public static int InterpolationSearch(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high && target >= arr[low] && target <= arr[high])
        {
            if (arr[high] == arr[low])
            {
                if (arr[low] == target)
                    return low;
                else
                    return -1;
            }

            int pos = low + ((target - arr[low]) * (high - low)) / (arr[high] - arr[low]);

            if (arr[pos] == target)
                return pos;
            else if (arr[pos] < target)
                low = pos + 1;
            else
                high = pos - 1;
        }

        return -1; 
    }
}