using MainHomeworkRequirements;

namespace zait_olzhas
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