using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoratorPattern.UnitTests
{
    [TestClass]
    public class ProjectSalaryDecoratorTests
    {
        [TestMethod]
        public void GetSalary_Junior_ShouldCalculateBonus()
        {
            // Arrange
            Employee employee = new JuniorDeveloper { NumberOfProjects = 3 };
            ProjectSalaryDecorator decorator = new ProjectSalaryDecorator(employee, 100);

            // Act
            var result = decorator.GetSalary();

            // Assert
            Assert.AreEqual(1300, result);
        }

        [TestMethod]
        public void GetSalary_Senior_ShouldCalculateBonus()
        {
            // Arrange
            Employee employee = new SeniorDeveloper { NumberOfProjects = 3 };
            ProjectSalaryDecorator decorator = new ProjectSalaryDecorator(employee, 100);

            // Act
            var result = decorator.GetSalary();

            // Assert
            Assert.AreEqual(2300, result);
        }
    }
}
