using MainHomeworkRequirements;

namespace zhaxybayev_askhat
{
    public class ArrayTasksSolution : IArrayTasks
    {
        public decimal GetSumOfAllNumbers(decimal[] numbers)
        {
            decimal summary = 0;
            foreach (var number in numbers) {
                summary += number;
            }
            return summary;
        }
    }
}