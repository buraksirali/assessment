using System;
using System.Collections.Generic;
using System.IO;

namespace P.I_Assessment
{
    class Program
    {
        static List<int> sums = new();
        static List<string[]> pyramid = new();

        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\4th_question.txt";
            string line;
            string[] numbers;

            StreamReader file = new (path);

            while ((line = file.ReadLine()) != null)
            {
                numbers = line.Split(" ");
                pyramid.Add(numbers);
            }

            file.Close();

            MoveDown(1, 0, int.Parse(pyramid[0][0]));
             
            int max = int.MinValue;
            foreach(int sum in sums)
            {
                if (sum > max)
                {
                    max = sum;
                }
            }

            Console.WriteLine($"{max}");
            Console.Read();
        }

        static void MoveDown(int floor, int index, int sum)
        {
            string[] numbers;

            if (floor < pyramid.Count) {
                numbers = pyramid[floor];
                int temp_sum = sum;

                if (!IsPrime(int.Parse(numbers[index])))
                {
                    temp_sum += int.Parse(numbers[index]);
                    MoveDown(floor + 1, index, temp_sum);
                }

                temp_sum = sum;

                if (!IsPrime(int.Parse(numbers[index + 1])))
                {
                    temp_sum += int.Parse(numbers[index + 1]);
                    MoveDown(floor + 1, index + 1, temp_sum);
                }
            } else
            {
                sums.Add(sum);
            }
        }

        static bool IsPrime(int num)
        {
            if (num < 4)
            {
                return true;
            }

            for(int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
    }
}
