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
    public class CollisionTests
    {
        [TestMethod()]
        public void Collision_GetTarget_WhenProvidedEntityIsRelevant_ShouldReturnProvidedEntity()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 0, 0);
            Entity e2 = new EntityWall(0, 0, 0, 0);
            Collision c1 = new Collision(e1, e2, 0);

            // Act
            Entity target = c1.GetTarget(e1);

            // Assert
            Assert.AreEqual(e1, target);
        }

        [TestMethod()]
        public void Collision_GetTarget_WhenProvidedEntityIsIrrelevant_ShouldReturnNull()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 0, 0);
            Entity e2 = new EntityWall(0, 0, 0, 0);
            Entity e3 = new EntityWall(0, 0, 0, 0);
            Collision c1 = new Collision(e1, e2, 0);

            // Act
            Entity target = c1.GetTarget(e3);

            // Assert
            Assert.AreEqual(null, target);
        }

        [TestMethod()]
        public void Collision_GetOther_WhenProvidedEntityIsRelevant_ShouldReturnOtherEntity()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 0, 0);
            Entity e2 = new EntityWall(0, 0, 0, 0);
            Collision c1 = new Collision(e1, e2, 0);

            // Act
            Entity target1 = c1.GetOther(e1);
            Entity target2 = c1.GetOther(e2);

            // Assert
            Assert.AreEqual(e2, target1);
            Assert.AreEqual(e1, target2);
        }

        [TestMethod()]
        public void Collision_GetOther_WhenProvidedEntityIsIrrelevant_ShouldReturnNull()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 0, 0);
            Entity e2 = new EntityWall(0, 0, 0, 0);
            Entity e3 = new EntityWall(0, 0, 0, 0);
            Collision c1 = new Collision(e1, e2, 0);

            // Act
            Entity target = c1.GetOther(e3);

            // Assert
            Assert.AreEqual(null, target);
        }

        [TestMethod()]
        public void Collision_IsRelevant_WhenProvidedEntityIsRelevant_ShouldReturnTrue()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 0, 0);
            Entity e2 = new EntityWall(0, 0, 0, 0);
            Collision c1 = new Collision(e1, e2, 0);

            // Act
            bool relevant1 = c1.IsRelevant(e1);
            bool relevant2 = c1.IsRelevant(e2);

            // Assert
            Assert.IsTrue(relevant1);
            Assert.IsTrue(relevant2);
        }

        [TestMethod()]
        public void Collision_IsRelevant_WhenProvidedEntityIsNotRelevant_ShouldReturnFalse()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 0, 0);
            Entity e2 = new EntityWall(0, 0, 0, 0);
            Entity e3 = new EntityWall(0, 0, 0, 0);
            Collision c1 = new Collision(e1, e2, 0);

            // Act
            bool relevant = c1.IsRelevant(e3);

            // Assert
            Assert.IsFalse(relevant);
        }
    }
}