using MainHomeworkRequirements;

namespace timur_naskenov
{
    public class ArrayTasksOfMine : IArrayTasks
    {
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