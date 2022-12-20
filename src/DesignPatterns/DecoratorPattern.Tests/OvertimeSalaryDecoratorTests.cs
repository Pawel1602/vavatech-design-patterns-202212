using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DecoratorPattern.UnitTests
{
    [TestClass]
    public class OvertimeSalaryDecoratorTests
    {
        [TestMethod]
        public void GetSalary_Junior_ShouldCalculateBonus()
        {
            // Arrange
            Employee employee = new JuniorDeveloper { OvertimeSalary = TimeSpan.FromHours(2) };
            OvertimeSalaryDecorator decorator = new OvertimeSalaryDecorator(employee, 100);

            // Act
            var result = decorator.GetSalary();

            // Assert
            Assert.AreEqual(1200, result);
        }

        [TestMethod]
        public void GetSalary_Senior_ShouldCalculateBonus()
        {
            // Arrange
            Employee employee = new SeniorDeveloper { OvertimeSalary = TimeSpan.FromHours(2) };
            OvertimeSalaryDecorator decorator = new OvertimeSalaryDecorator(employee, 100);

            // Act
            var result = decorator.GetSalary();

            // Assert
            Assert.AreEqual(2200, result);
        }
    }
}
