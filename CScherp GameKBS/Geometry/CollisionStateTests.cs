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
    public class CollisionStateTests
    {
        [TestMethod()]
        public void CollisionState_Rectangle_ShouldReturnEntityAtCurrentHypotheticalFlooredPosition()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);

            // Act
            cs1.Next();
            Rectangle r1 = cs1.Rectangle;

            // Assert
            Assert.AreEqual(new Vector(1, 0), cs1.Rectangle.Position);
        }

        [TestMethod()]
        public void CollisionState_Fraction_ShouldReturnOffsetDividedBySpeed()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);
            
            double expected = 1 / e1.Speed.Length;

            // Act
            cs1.Next();
            double frac = cs1.Fraction;

            // Assert
            Assert.AreEqual(expected, frac);
        }

        [TestMethod()]
        public void CollisionState_Done_WhenOffsetSmallerThanSpeed_ShouldReturnFalse()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);
            
            // Act
            cs1.Next();

            // Assert
            Assert.IsFalse(cs1.Done);
        }

        [TestMethod()]
        public void CollisionState_Done_WhenOffsetEqualsSpeed_ShouldReturnTrue()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);

            // Act
            for (int i = 0; i < 4; i++)
                cs1.Next();

            // Assert
            Assert.IsTrue(cs1.Done);
        }

        [TestMethod()]
        public void CollisionState_Done_WhenOffsetGreaterThanSpeed_ShouldReturnTrue()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);

            // Act
            for (int i = 0; i < 5; i++)
                cs1.Next();

            // Assert
            Assert.IsTrue(cs1.Done);
        }

        [TestMethod()]
        public void CollisionState_Next_ShouldAddStepToOffset()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);

            Vector expected = new Vector(1, 0);

            // Act
            cs1.Next();

            // Assert
            Assert.AreEqual(expected, cs1.Rectangle.Position);
        }

        [TestMethod()]
        public void CollisionState_Previous_ShouldSubtractStepFromOffset()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(4, 0);

            CollisionState cs1 = new CollisionState(e1, 4);

            Vector expected = new Vector(1, 0);

            // Act
            cs1.Next();
            cs1.Next();
            cs1.Previous();

            // Assert
            Assert.AreEqual(expected, cs1.Rectangle.Position);
        }
    }
}