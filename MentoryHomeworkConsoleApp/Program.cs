﻿using yermagambetov_daniyar;
using zait_olzhas;

namespace MentoryHomeworkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrayTasks = new ArrayTasksOfMine();
            decimal[] numbers = { 1, 2, 3, 4, 5 };
            decimal sum = arrayTasks.GetSumOfAllNumbers(numbers);
            Console.WriteLine(sum);
            var array1 = new array();
            var result = array1.GetSumOfAllNumbers(numbers);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}