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
    public class EntityObstacleMovingTests
    {
        [TestMethod()]
        public void EntityObstacleMovingTest_WhenMovingHorizontal_XPositionChanges()
        {
            // Arrange
            Level level = new Level(null, 200, 200);

            EntityObstacleMoving obstacle = new EntityObstacleMoving(10, 10, 1, 0);
            level.SpawnEntity(obstacle);

            Vector StartPosition = obstacle.Position;

            // Act
            level.Update(1);

            // Assert
            Assert.AreNotEqual(StartPosition.X, obstacle.Position.X);
        }

        [TestMethod()]
        public void EntityObstacleMovingTest_WhenMovingVertical_YPositionChanges()
        {
            // Arrange
            Level level = new Level(null, 200, 200);

            EntityObstacleMoving obstacle = new EntityObstacleMoving(10, 10, 0, 1);
            level.SpawnEntity(obstacle);

            Vector StartPosition = obstacle.Position;

            // Act
            level.Update(1);

            // Assert
            Assert.AreNotEqual(StartPosition.Y, obstacle.Y1);
        }

        [TestMethod()]
        public void EntityObstacleMovingTest_WhenMovingHorizontalAndHittingLeftSideOfScreen_Speed_XBecomesPositive()
        {
            // Arrange
            Level level = new Level(null, 200, 200);

            EntityObstacleMoving obstacle = new EntityObstacleMoving(0, 0, -1, 0);
            level.SpawnEntity(obstacle);

            // Act
            level.Update(1);

            // Arrange
            Assert.IsTrue(obstacle.Speed.X.IsPositive());
        }

        [TestMethod()]
        public void EntityObstacleMovingTest_WhenMovingHorizontalAndHittingRightSideOfScreen_Speed_XBecomesNegative()
        {
            // Arrange
            Level level = new Level(null, 200, 200);

            EntityObstacleMoving obstacle = new EntityObstacleMoving(0, 0, 1, 0);
            obstacle.X2 = 199;
            level.SpawnEntity(obstacle);

            // Act
            level.Update(1);

            // Arrange
            Assert.IsTrue(obstacle.Speed.X.IsNegative());
        }

        [TestMethod()]
        public void EntityObstacleMovingTest_WhenMovingVerticalAndHittingBottomSideOfScreen_Speed_YBecomesNegative()
        {
            // Arrange
            Level level = new Level(null, 200, 200);

            EntityObstacleMoving obstacle = new EntityObstacleMoving(0, 0, 0, 1);
            obstacle.Y2 = 199;
            level.SpawnEntity(obstacle);

            // Act
            level.Update(1);

            // Arrange
            Assert.IsTrue(obstacle.Speed.Y.IsNegative());
        }

        [TestMethod()]
        public void EntityObstacleMovingTest_WhenMovingVerticalAndHittingTopSideOfScreen_Speed_YBecomesPositive()
        {
            // Arrange
            Level level = new Level(null, 200, 200);

            EntityObstacleMoving obstacle = new EntityObstacleMoving(0, 0, 0, -1);
            level.SpawnEntity(obstacle);

            // Act
            level.Update(1);

            // Arrange
            Assert.IsTrue(obstacle.Speed.Y.IsPositive());
        }
    }
}