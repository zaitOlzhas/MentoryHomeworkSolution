using MainHomeworkRequirements;

namespace zait_olzhas
{
    public class ArrayTasksOfMine : IArrayTasks
    {
        /// <summary>
        /// This method returns sum of all numbers in array.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public decimal GetSumOfAllNumbers(decimal[] numbers)
        {
            decimal sum = 0;
            foreach (decimal number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }
}