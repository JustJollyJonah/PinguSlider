using Microsoft.VisualStudio.TestTools.UnitTesting;
using CScherp_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game.Tests
{
    [TestClass()]
    public class VectorHelperTests
    {
        [TestMethod()]
        public void VectorHelper_Min_ShouldReturnLowestArgument()
        {
            // Arrange
            double a = 5d;
            double b = 9d;
            double c = 2d;

            // Act
            double lowest = a.Min(b, c);

            // Assert
            Assert.AreEqual(c, lowest);
        }

        [TestMethod()]
        public void VectorHelper_Max_ShouldReturnHighestArgument()
        {
            // Arrange
            double a = 5d;
            double b = 9d;
            double c = 2d;

            // Act
            double highest = a.Max(b, c);

            // Assert
            Assert.AreEqual(b, highest);
        }

        [TestMethod()]
        public void VectorHelper_IsPositive_WhenPositive_ShouldReturnTrue()
        {
            // Arrange
            double a = 5d;
            double b = 1d;

            // Act
            bool result1 = a.IsPositive();
            bool result2 = b.IsPositive();

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod()]
        public void VectorHelper_IsPositive_WhenZero_ShouldReturnTrue()
        {
            // Arrange
            double a = 0d;

            // Act
            bool result = a.IsPositive();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void VectorHelper_IsPositive_WhenNegative_ShouldReturnFalse()
        {
            // Arrange
            double a = -5d;
            double b = -0.1d;

            // Act
            bool result1 = a.IsPositive();
            bool result2 = b.IsPositive();

            // Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }


        [TestMethod()]
        public void VectorHelper_IsNegative_WhenPositive_ShouldReturnFalse()
        {
            // Arrange
            double a = 5d;
            double b = 1d;

            // Act
            bool result1 = a.IsNegative();
            bool result2 = b.IsNegative();

            // Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod()]
        public void VectorHelper_IsNegative_WhenZero_ShouldReturnFalse()
        {
            // Arrange
            double a = 0d;

            // Act
            bool result = a.IsNegative();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void VectorHelper_IsNegative_WhenNegative_ShouldReturnTrue()
        {
            // Arrange
            double a = -5d;
            double b = -0.1d;

            // Act
            bool result1 = a.IsNegative();
            bool result2 = b.IsNegative();

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod()]
        public void VectorHelper_Floor_ShouldRoundDown()
        {
            // Arrange
            double a = 5.3;
            double b = 1.2;

            // Act
            int c = a.Floor();
            int d = b.Floor();

            // Assert
            Assert.AreEqual(5, c);
            Assert.AreEqual(1, d);
        }

        [TestMethod()]
        public void VectorHelper_Ceiling_ShouldRoundUp()
        {
            // Arrange
            double a = 5.3;
            double b = 1.2;

            // Act
            int c = a.Ceiling();
            int d = b.Ceiling();

            // Assert
            Assert.AreEqual(6, c);
            Assert.AreEqual(2, d);
        }
    }
}