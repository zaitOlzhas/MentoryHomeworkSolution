using MainHomeworkRequirements;

namespace yernur_zhex
{
    public class MyArray : IArrayTasks
    {
        public decimal GetSumOfAllNumbers(decimal[] numbers)
        {
            return numbers.Sum();
        }
    }
}