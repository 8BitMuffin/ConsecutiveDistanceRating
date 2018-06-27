using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveDistanceRating
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = GetInput();
            var result = GetConsecutiveDistanceRatings(input);
            foreach (var distanceRating in result)
            {
                Console.WriteLine(distanceRating);
            }
            Console.ReadLine();
        }

        private static IEnumerable<string> GetConsecutiveDistanceRatings(int[][] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var distanceRating = input[i].Aggregate(0, (total, n) => total + (Array.IndexOf(input[i], n + 1) < 0 ? 0 : Math.Abs(Array.IndexOf(input[i], n) - Array.IndexOf(input[i], n+1))));
                yield return distanceRating.ToString();
            }
        }
        private static int[][] GetInput()
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Challenge_1.txt");
            int[][] input;
            using (var file = File.OpenText(path))
            {
                var firstLine = file.ReadLine().Split(' ');
                var sequences = Convert.ToInt32(firstLine[0]);
                var length = Convert.ToInt32(firstLine[1]);
                input = new int[sequences][];
                int counter = 0;
                while (counter < sequences)
                {
                    var line = file.ReadLine().Split(' ').Select(c => Convert.ToInt32(c)).ToArray();
                    input[counter] = line;
                    counter++;
                }
            }

            return input;
        }
    }
}
