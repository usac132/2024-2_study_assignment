using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            double Math_Sum = 0, Science_Sum = 0, English_Sum = 0;
            double Math_Max = double.Parse(data[1, 2]);
            double Science_Max = double.Parse(data[1, 3]);
            double English_Max = double.Parse(data[1, 4]);
            double Math_Min = double.Parse(data[1, 2]);
            double Science_Min = double.Parse(data[1, 3]);
            double English_Min = double.Parse(data[1, 4]);
            double[] TotalScore = new double[stdCount];
            double[] idx = new double[stdCount];
            Dictionary<int, string> sequence = new Dictionary<int, string>();
            sequence[0] = "1st";
            sequence[1] = "2nd";
            sequence[2] = "3rd";
            sequence[3] = "4th";
            sequence[4] = "5th";

            for (int i = 1; i < stdCount + 1; i++)
            {
                Math_Sum += double.Parse(data[i, 2]);
                Science_Sum += double.Parse(data[i, 3]);
                English_Sum += double.Parse(data[i, 4]);

                if (double.Parse(data[i, 2]) > Math_Max) Math_Max = double.Parse(data[i, 2]);
                if (double.Parse(data[i, 3]) > Science_Max) Science_Max = double.Parse(data[i, 3]);
                if (double.Parse(data[i, 4]) > English_Max) English_Max = double.Parse(data[i, 4]);

                if (double.Parse(data[i, 2]) < Math_Min) Math_Min = double.Parse(data[i, 2]);
                if (double.Parse(data[i, 3]) < Science_Min) Science_Min = double.Parse(data[i, 3]);
                if (double.Parse(data[i, 4]) < English_Min) English_Min = double.Parse(data[i, 4]);

                TotalScore[i - 1] = double.Parse(data[i, 2]) + double.Parse(data[i, 3]) + double.Parse(data[i, 4]);
                idx[i - 1] = i - 1; ;
            }
            Array.Sort(idx, (a, b) => TotalScore[(int)a].CompareTo(TotalScore[(int)b]));


            Console.WriteLine("Average Scores:");
            Console.WriteLine($"Math: {Math_Sum / stdCount:F2}");
            Console.WriteLine($"Science: {Science_Sum / stdCount:F2}");
            Console.WriteLine($"English: {English_Sum / stdCount:F2}\n");

            Console.WriteLine("Max and min Scores:");
            Console.WriteLine($"Math: ({Math_Max}, {Math_Min})");
            Console.WriteLine($"Science: ({Science_Max}, {Science_Min})");
            Console.WriteLine($"English: ({English_Max}, {English_Min})\n");

            Console.WriteLine("Students rank by total scores:");
            for (int i = 0; i < stdCount; i++)
            {
                Console.WriteLine($"{data[i + 1, 1]}: {sequence[Array.IndexOf(idx, i)]}");
            }
            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd

*/
