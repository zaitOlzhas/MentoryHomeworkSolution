using MainHomeworkRequirements;

namespace aituar_erzhan
{
    public class Array : IArrayTasks
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

