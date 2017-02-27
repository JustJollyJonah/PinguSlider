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
    public class RectangleTests
    {
        [TestMethod()]
        public void Rectangle_X2Get_ShouldReturnPositionPlusSizeMinusOne()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            double expected = r1.Position.X + r1.Width - 1;

            // Act
            double x2 = r1.X2;

            // Assert
            Assert.AreEqual(expected, x2);
        }

        [TestMethod()]
        public void Rectangle_X2Set_ShouldUpdatePositionToValueMinusSizePlusOne()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            double value = 10;
            double expected = value - r1.Width + 1;

            // Act
            r1.X2 = 10;

            // Assert
            Assert.AreEqual(expected, r1.X1);
        }

        [TestMethod()]
        public void Rectangle_Y2Get_ShouldReturnPositionPlusSizeMinusOne()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            double expected = r1.Position.Y + r1.Height - 1;

            // Act
            double y2 = r1.Y2;

            // Assert
            Assert.AreEqual(expected, y2);
        }

        [TestMethod()]
        public void Rectangle_Y2Set_ShouldUpdatePositionToValueMinusSizePlusOne()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            double value = 10;
            double expected = value - r1.Height + 1;

            // Act
            r1.Y2 = 10;

            // Assert
            Assert.AreEqual(expected, r1.Y1);
        }

        [TestMethod()]
        public void Rectangle_Floored_ShouldReturnFlooredRectangle()
        {
            // Arrange
            Rectangle r1 = new Rectangle(5.9, 2.1, 1.1, 9.5);

            // Act
            Rectangle r2 = r1.Floored;

            // Assert
            Assert.AreEqual(5, r2.X1);
            Assert.AreEqual(2, r2.Y1);
            Assert.AreEqual(1, r2.Width);
            Assert.AreEqual(9, r2.Height);
        }

        [TestMethod()]
        public void Rectangle_IntersectsRectangle_WhenNoOverlap_ShouldReturnFalse()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            Rectangle r2 = new Rectangle(10, 0, 10, 10);

            // Act
            bool result = r1.Intersects(r2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Rectangle_IntersectsRectangle_WhenCollide_ShouldReturnFalse()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            Rectangle r2 = new Rectangle(10, 10, 10, 10);

            // Act
            bool result = r1.Intersects(r2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Rectangle_IntersectsRectangle_WhenOverlap_ShouldReturnTrue()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            Rectangle r2 = new Rectangle(5, 5, 10, 10);

            // Act
            bool result = r1.Intersects(r2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Rectangle_IntersectsRectangle_WhenIdentical_ShouldReturnTrue()
        {
            // Arrange
            Rectangle r = new Rectangle(0, 0, 10, 10);

            // Act
            bool result = r.Intersects(r);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Rectangle_IntersectsVector_WhenInside_ShouldReturnTrue()
        {
            // Arrange
            Rectangle r = new Rectangle(0, 0, 10, 10);
            Vector v1 = new Vector(5, 5);
            Vector v2 = new Vector(9, 9);

            // Act
            bool result1 = r.Intersects(v1);
            bool result2 = r.Intersects(v2);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod()]
        public void Rectangle_IntersectsVector_WhenOnBorder_ShouldReturnTrue()
        {
            // Arrange
            Rectangle r = new Rectangle(0, 0, 10, 10);
            Vector v1 = new Vector(0, 0);
            Vector v2 = new Vector(9, 9);

            // Act
            bool result1 = r.Intersects(v1);
            bool result2 = r.Intersects(v2);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod()]
        public void Rectangle_IntersectsVector_WhenOutside_ShouldReturnFalse()
        {
            // Arrange
            Rectangle r = new Rectangle(0, 0, 10, 10);
            Vector v1 = new Vector(5, 10);
            Vector v2 = new Vector(10, 5);

            // Act
            bool result1 = r.Intersects(v1);
            bool result2 = r.Intersects(v2);

            // Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod()]
        public void Rectangle_GetCenter_WhenEvenDimensions_ShouldReturnWithDecimals()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 10, 10);
            Rectangle r2 = new Rectangle(5, 10, 4, 4);

            // Act
            Vector v1 = r1.GetCenter();
            Vector v2 = r2.GetCenter();

            // Assert
            Assert.AreEqual(new Vector(4.5, 4.5), v1);
            Assert.AreEqual(new Vector(6.5, 11.5), v2);
        }

        [TestMethod()]
        public void Rectangle_GetCenter_WhenUnevenDimensions_ShouldReturnWithoutDecimals()
        {
            // Arrange
            Rectangle r1 = new Rectangle(0, 0, 9, 9);
            Rectangle r2 = new Rectangle(5, 10, 3, 3);

            // Act
            Vector v1 = r1.GetCenter();
            Vector v2 = r2.GetCenter();

            // Assert
            Assert.AreEqual(new Vector(4, 4), v1);
            Assert.AreEqual(new Vector(6, 11), v2);
        }

        [TestMethod()]
        public void Rectangle_AtPosition_ShouldReturnRectangleAtPositionWithOldDimensions()
        {
            // Arrange
            Rectangle r1 = new Rectangle(5, 5, 10, 10);
            Vector v1 = new Vector(0, 0);

            // Act
            Rectangle r2 = r1.AtPosition(v1);

            // Assert
            Assert.AreEqual(v1, r2.Position);
            Assert.AreEqual(r1.Size, r2.Size);
        }

        [TestMethod()]
        public void Rectangle_AtPosition_ShouldReturnNewRectangleWithOldDimensions()
        {
            // Arrange
            Rectangle r1 = new Rectangle(5, 5, 10, 10);
            Vector v1 = new Vector(0, 0);

            // Act
            Rectangle r2 = r1.AtPosition(v1);

            // Assert
            Assert.AreNotEqual(r1, r2);
            Assert.AreEqual(r1.Size, r2.Size);
        }

    }
}