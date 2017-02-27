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
    public class CollisionHelperTests
    {
        [TestMethod()]
        public void CollisionHelper_FindCollision_WhenWillCollide_ShouldReturnCollision()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 5, 5); // X1=0, Y1=0, X2=4, Y2=4
            Entity e2 = new EntityWall(5, 0, 5, 5); // X1=5, Y1=0, X2=9, Y2=9

            e1.Speed = new Vector(1, 0);
            e2.Speed = new Vector(-1, 0);

            // Act
            Collision c1 = e1.FindCollision(e2);
            Collision c2 = e2.FindCollision(e1);

            // Assert
            Assert.IsNotNull(c1);
            Assert.IsNotNull(c2);
        }

        [TestMethod()]
        public void CollisionHelper_FindCollision_WhenAreAlreadyColliding_ShouldReturnCollisionWithZeroFractionBefore()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 5, 5); // X1=0, Y1=0, X2=4, Y2=4
            Entity e2 = new EntityWall(5, 0, 5, 5); // X1=5, Y1=0, X2=9, Y2=9

            e1.Speed = new Vector(1, 0);
            e2.Speed = new Vector(-1, 0);

            // Act
            Collision c1 = e1.FindCollision(e2);
            Collision c2 = e2.FindCollision(e1);

            // Assert
            Assert.AreEqual(0, c1.FractionBefore);
            Assert.AreEqual(0, c2.FractionBefore);
        }

        [TestMethod()]
        public void CollisionHelper_FindCollision_WhenWillEndAsCollision_ShouldReturnNull()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 5, 5); // X1=0, Y1=0, X2=4, Y2=4
            Entity e2 = new EntityWall(7, 0, 5, 5); // X1=5, Y1=0, X2=9, Y2=9

            e1.Speed = new Vector(1, 0);
            e2.Speed = new Vector(-1, 0);

            // Act
            Collision c1 = e1.FindCollision(e2);
            Collision c2 = e2.FindCollision(e1);

            // Assert
            Assert.IsNull(c1);
            Assert.IsNull(c2);
        }

        [TestMethod()]
        public void CollisionHelper_FindCollision_WhenNoMovingEntity_ShouldReturnNull()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 5, 5); // X1=0, Y1=0, X2=4, Y2=4
            Entity e2 = new EntityWall(5, 0, 5, 5); // X1=5, Y1=0, X2=9, Y2=9

            // Act
            Collision c1 = e1.FindCollision(e2);
            Collision c2 = e2.FindCollision(e1);

            // Assert
            Assert.IsNull(c1);
            Assert.IsNull(c2);
        }
    }
}