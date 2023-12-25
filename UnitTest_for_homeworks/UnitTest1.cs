using MainHomeworkRequirements;
using Moq;
using System.Reflection;

namespace UnitTest_for_homeworks
{
    [TestClass]
    public class UnitTestForArrayTasks
    {
        [TestMethod]
        public void GetSumOfAllNumbers()
        {
            var assemblies = new[]
            {
                Assembly.Load("zait_olzhas"),
                Assembly.Load("yernur_zhex"),
                Assembly.Load("kassymov_daulet"),
                Assembly.Load("issakov_alexey")
                // Add more assemblies as needed
            };
            var failures = new List<string>();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                                    .Where(t => t.GetInterfaces().Contains(typeof(IArrayTasks)) && !t.IsInterface);


                foreach (var type in types)
                {
                    try
                    {
                        // Arrange
                        var mock = new Mock<IArrayTasks>();
                        decimal[] numbers = { 1, 2, 3, 4, 5 };
                        mock.Setup(service => service.GetSumOfAllNumbers(numbers));
                        var classUnderTest = Activator.CreateInstance(type) as IArrayTasks;

                        // Act
                        var result = classUnderTest.GetSumOfAllNumbers(numbers);

                        // Assert
                        Assert.AreEqual(15,result);
                    }
                    catch (AssertFailedException)
                    {
                        lock (failures)
                        {
                            failures.Add(type.FullName);
                        }
                    }

                }
            }
            if (failures.Any())
            {
                Assert.Fail("Failures for types: \r\n" + string.Join("\r\n", failures));
            }
        }
    }
}