using MainHomeworkRequirements;

namespace issakov_alexey
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

