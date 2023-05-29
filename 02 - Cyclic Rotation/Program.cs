/*
Assumptions:
    - N and K are integers within the range [0..100];
    - each element of array A is an integer within the range [−1,000..1,000].
*/

public class CyclicRotationSolver
{
    public static void Main()
    {
        var randomGenerator = new Random();
        for (int i = 0; i < 10; i++)
        {
            var array = GenerateRandomArrayOfSize(randomGenerator.Next(0, 100));
            int K = randomGenerator.Next(0, 100);
            var rotatedArray = RotateArrayRight(array, K);
            Console.Write("Start array: ");
            PrintArray(array);
            Console.WriteLine($"K = {K}");
            Console.Write("Rotated array: ");
            PrintArray(rotatedArray);
            Console.Write("\n");
        }
    }

    private static void PrintArray(int[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("empty array");
        }

        for (int j = 0; j < array.Length; j++)
        {
            Console.Write(array[j]);
            Console.Write(j < array.Length - 1 ? "," : "\n");
        }
    }

    private static int[] GenerateRandomArrayOfSize(int size)
    {
        int[] result = new int[size];
        var randomGenerator = new Random();

        for (int i = 0; i < size; i++)
        {
            result[i] = randomGenerator.Next(-1000, 1000);
        }

        return result;
    }

    private static int[] RotateArrayRight(int[] A, int K)
    {
        if (A.Length == 0 || K == 0)
        {
            return A;
        }

        K %= A.Length;

        if (A.Length == K)
        {
            return A;
        }

        int[] result = new int[A.Length];
        int[] tmp = new int[K];
        Array.Copy(A, A.Length - K, tmp, 0, K);
        Array.Copy(tmp, result, tmp.Length);
        Array.Copy(A, 0, result, K, A.Length - K);

        return result;
    }
}
