using MainHomeworkRequirements;

namespace kassymov_daulet
{
    public class ArrayKassymov : IArrayTasks
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