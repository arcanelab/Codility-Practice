
public class BinaryGapSolver
{
    public static void Main()
    {
        var randomGenerator = new Random();
        for (int i = 0; i < 10; i++)
        {
            int number = Math.Abs(randomGenerator.Next());
            int lbg = CalculateLongestBinaryGap(number);
            Console.WriteLine($"{Convert.ToString(number, 2)} = {lbg}");
        }
    }

    static int CalculateLongestBinaryGap(int number)
    {
        const int bits = sizeof(int) * 8;
        int longestBinaryGap = 0;
        int currentBinaryGap = 0;
        bool counting = false;

        for (int i = 0; i < bits; i++)
        {
            // lSB = least significant bit
            bool LSB = ((number >> i) & 1) == 1;

            if (LSB)
            {
                counting = true;
                longestBinaryGap = Math.Max(longestBinaryGap, currentBinaryGap);
                currentBinaryGap = 0;
            }
            else
            {
                if (counting)
                {
                    currentBinaryGap++;
                }
            }
        }

        return longestBinaryGap;
    }
}
