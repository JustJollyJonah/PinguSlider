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
    public class VectorTests
    {

        [TestMethod()]
        public void Vector_AddFunction()
        {
            // Arrange
            Vector a = new Vector(3, 9);

            // Act
            Vector b = a.Add(2, 0.5);

            // Assert
            Assert.AreEqual(5, b.X, 0.00001);
            Assert.AreEqual(9.5, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_AddOperator()
        {
            // Arrange
            Vector a = new Vector(1, 2);
            Vector b = new Vector(3, 4);

            // Act
            Vector c = a + b;

            // Assert
            Assert.AreEqual(4, c.X, 0.00001);
            Assert.AreEqual(6, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_SubtractFunction()
        {
            // Arrange
            Vector a = new Vector(10, 2.9);

            // Act
            Vector b = a.Subtract(3, 1.4);

            // Assert
            Assert.AreEqual(7, b.X, 0.00001);
            Assert.AreEqual(1.5, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_SubtractOperator()
        {
            // Arrange
            Vector a = new Vector(10, 5);
            Vector b = new Vector(2, 3.5);

            // Act
            Vector c = a - b;

            // Assert
            Assert.AreEqual(8, c.X, 0.00001);
            Assert.AreEqual(1.5, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_MultiplyFunction()
        {
            // Arrange
            Vector a = new Vector(1.2, 9.5);

            // Act
            Vector b = a.Multiply(2, 2);

            // Assert
            Assert.AreEqual(2.4, b.X, 0.00001);
            Assert.AreEqual(19, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_MultiplyOtherVectorOperator()
        {
            // Arrange
            Vector a = new Vector(3, 4);
            Vector b = new Vector(0.5, 9);

            // Act
            Vector c = a * b;

            // Assert
            Assert.AreEqual(1.5, c.X, 0.00001);
            Assert.AreEqual(36, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_MultiplyNumberOperator()
        {
            // Arrange
            Vector a = new Vector(26.5, 9.2);

            // Act
            Vector b = a * 3;

            // Assert
            Assert.AreEqual(79.5, b.X, 0.00001);
            Assert.AreEqual(27.6, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_DivideFunction()
        {
            // Arrange
            Vector a = new Vector(4, 8);

            // Act
            Vector b = a.Divide(2, 2);

            // Assert
            Assert.AreEqual(2, b.X, 0.00001);
            Assert.AreEqual(4, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_DivideVectorOperator()
        {
            // Arrange
            Vector a = new Vector(10, 12);
            Vector b = new Vector(5, 4);

            // Act
            Vector c = a / b;

            // Assert
            Assert.AreEqual(2, c.X, 0.00001);
            Assert.AreEqual(3, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_DivideNumberOperator()
        {
            // Arrange
            Vector a = new Vector(30, 6);

            // Act
            Vector b = a / 3;

            // Assert
            Assert.AreEqual(10, b.X, 0.00001);
            Assert.AreEqual(2, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_NegateFunction()
        {
            // Arrange
            Vector a = new Vector(-5, 10);

            // Act
            Vector b = a.Negate();

            // Assert
            Assert.AreEqual(5, b.X, 0.00001);
            Assert.AreEqual(-10, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_NegateOperator()
        {
            // Arrange
            Vector a = new Vector(-5, 10);

            // Act
            Vector b = !a;

            // Assert
            Assert.AreEqual(5, b.X, 0.00001);
            Assert.AreEqual(-10, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_SmallerThanOperator()
        {
            // Arrange
            Vector a = new Vector(2, 3);
            Vector b = new Vector(5, 9);
            Vector c = new Vector(2, 3);

            // Act
            bool result1 = a < b;
            bool result2 = b < a;
            bool result3 = a < c;

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod()]
        public void Vector_GreaterThanOperator()
        {
            // Arrange
            Vector a = new Vector(1, 2);
            Vector b = new Vector(2, 4);
            Vector c = new Vector(1, 2);

            // Act
            bool result1 = a > b;
            bool result2 = b > a;
            bool result3 = a > c;

            // Assert
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod()]
        public void Vector_SmallerThanOrEqualToOperator()
        {
            // Arrange
            Vector a = new Vector(3, 9);
            Vector b = new Vector(3, 6);
            Vector c = new Vector(3, 6);

            // Act
            bool result1 = a <= b;
            bool result2 = b <= a;
            bool result3 = b <= c;

            // Assert
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod()]
        public void Vector_GreaterThanOrEqualToOperator()
        {
            // Arrange
            Vector a = new Vector(4, 0);
            Vector b = new Vector(4, 0);
            Vector c = new Vector(2, 9);

            // Act
            bool result1 = a >= b;
            bool result2 = b >= a;
            bool result3 = b >= c;
            bool result4 = c >= b;

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod()]
        public void Vector_Delta()
        {
            // Arrange
            Vector a = new Vector(1, 1);
            Vector b = new Vector(3, 2);

            // Act
            Vector c = a.Delta(b);

            // Assert
            Assert.AreEqual(2, c.X, 0.00001);
            Assert.AreEqual(1, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_Distance()
        {
            // Arrange
            Vector a = new Vector(0, 0);
            Vector b = new Vector(4, 0);
            Vector c = new Vector(2, 3);

            // Act
            double distance1 = a.Distance(b);
            double distance2 = b.Distance(c);

            // Assert
            Assert.AreEqual(4, distance1, 0.00001);
            Assert.AreEqual(3.6056, distance2, 0.0001);
        }

        [TestMethod()]
        public void Vector_Normalize()
        {
            // Arrange
            Vector a = new Vector(0, 4);
            Vector b = new Vector(3, 3);

            // Act
            Vector c = a.Normalize();
            Vector d = b.Normalize();

            // Assert
            Assert.AreEqual(0, c.X, 0.00001);
            Assert.AreEqual(1, c.Y, 0.00001);
            Assert.AreEqual(0.707107, d.X, 0.0001);
            Assert.AreEqual(0.707107, d.Y, 0.0001);
        }

        [TestMethod()]
        public void Vector_Length()
        {
            // Arrange
            Vector a = new Vector(0, 4);
            Vector b = new Vector(2, 3);

            // Act
            double length1 = a.Length;
            double length2 = b.Length;

            // Assert
            Assert.AreEqual(4, length1, 0.00001);
            Assert.AreEqual(3.60555, length2, 0.00001);
        }

        [TestMethod()]
        public void Vector_SetX()
        {
            // Arrange
            Vector a = new Vector(9, 10);

            // Act
            Vector b = a.SetX(0);

            // Assert
            Assert.AreEqual(0, b.X, 0.00001);
            Assert.AreEqual(10, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_SetY()
        {
            // Arrange
            Vector a = new Vector(3, 5);

            // Act
            Vector b = a.SetY(23.5);

            // Assert
            Assert.AreEqual(3, b.X, 0.00001);
            Assert.AreEqual(23.5, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_GetX_ShouldReturnOnlyXComponentVector()
        {
            // Arrange
            Vector a = new Vector(4, 5);

            // Act
            Vector b = a.GetX();

            // Assert
            Assert.AreEqual(4, b.X, 0.00001);
            Assert.AreEqual(0, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_GetY_ShouldReturnOnlyYComponentVector()
        {
            // Arrange
            Vector a = new Vector(4, 5);

            // Act
            Vector b = a.GetY();

            // Assert
            Assert.AreEqual(0, b.X, 0.00001);
            Assert.AreEqual(5, b.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_Minimum_WhenArgumentsAreNotNull_ShouldReturnLowestComponentsVector()
        {
            // Arrange
            Vector a = new Vector(5, 6);

            // Act
            Vector b = a.Minimum(3, 9);
            Vector c = a.Minimum(6, 2);

            // Assert
            Assert.AreEqual(3, b.X, 0.00001);
            Assert.AreEqual(6, b.Y, 0.00001);
            Assert.AreEqual(5, c.X, 0.00001);
            Assert.AreEqual(2, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_Minimum_WhenSomeArgumentsAreNull_ShouldReturnLowestComponentsVector()
        {
            // Arrange
            Vector a = new Vector(5, 6);

            // Act
            Vector b = a.Minimum(null, 3);
            Vector c = a.Minimum(22, null);
            Vector d = a.Minimum(null, null);

            // Assert
            Assert.AreEqual(5, b.X, 0.00001);
            Assert.AreEqual(3, b.Y, 0.00001);
            Assert.AreEqual(5, c.X, 0.00001);
            Assert.AreEqual(6, c.Y, 0.00001);
            Assert.AreEqual(5, d.X, 0.00001);
            Assert.AreEqual(6, d.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_Maximum_WhenArgumentsAreNotNull_ShouldReturnHighestComponentsVector()
        {
            // Arrange
            Vector a = new Vector(5, 6);

            // Act
            Vector b = a.Maximum(2, 9);
            Vector c = a.Maximum(6, 2);

            // Assert
            Assert.AreEqual(5, b.X, 0.00001);
            Assert.AreEqual(9, b.Y, 0.00001);
            Assert.AreEqual(6, c.X, 0.00001);
            Assert.AreEqual(6, c.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_Maximum_WhenSomeArgumentsAreNull_ShouldReturnHighestComponentsVector()
        {
            // Arrange
            Vector a = new Vector(5, 6);

            // Act
            Vector b = a.Maximum(null, 3);
            Vector c = a.Maximum(22, null);
            Vector d = a.Maximum(null, null);

            // Assert
            Assert.AreEqual(5, b.X, 0.00001);
            Assert.AreEqual(6, b.Y, 0.00001);
            Assert.AreEqual(22, c.X, 0.00001);
            Assert.AreEqual(6, c.Y, 0.00001);
            Assert.AreEqual(5, d.X, 0.00001);
            Assert.AreEqual(6, d.Y, 0.00001);
        }

        [TestMethod()]
        public void Vector_Equals_WhenComponentsAreSame_ShouldReturnTrue()
        {
            // Arrange
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, 2);

            // Act
            bool equals = a.Equals(b);

            // Assert
            Assert.IsTrue(equals);
        }

        [TestMethod()]
        public void Vector_Equals_WhenComponentsAreNotSame_ShouldReturnFalse()
        {
            // Arrange
            Vector a = new Vector(1, 2);
            Vector b = new Vector(3, 4);

            // Act
            bool equals = a.Equals(b);

            // Assert
            Assert.IsFalse(equals);
        }
    }
}