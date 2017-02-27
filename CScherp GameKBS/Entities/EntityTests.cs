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
    public class EntityTests
    {
        [TestMethod()]
        public void Entity_OnSpawn_ShouldRegisterEventHandlersWithLevel()
        {
            // Arrange
            Level l = new Level(null, 200, 200);
            Entity e1 = new EntityWall(0, 0, 10, 10);
            Entity e2 = new EntityWall(10, 0, 10, 10);

            // Zet ze op een bots koers
            e1.Speed = new Vector(1, 0);
            e2.Speed = new Vector(-1, 0);

            // Act
            l.SpawnEntity(e1);
            l.SpawnEntity(e2);
            l.Update(1);

            // We checken of de event handlers geregistreerd zijn door
            // een botsing te simuleren. Als ze botsen, dan is de handler
            // dus successvol geregistreerd.

            // Assert
            Assert.AreEqual(new Vector(0, 0), e1.Position);
            Assert.AreEqual(new Vector(10, 0), e2.Position);
        }

        [TestMethod()]
        public void Entity_OnDestroy_ShouldUnregisterEventHandlersWithLevel()
        {
            // Arrange
            Level l = new Level(null, 200, 200);
            Entity e1 = new EntityWall(0, 0, 10, 10);
            Entity e2 = new EntityWall(10, 0, 10, 10);

            // Zet ze op een bots koers
            e1.Speed = new Vector(1, 0);
            e2.Speed = new Vector(-1, 0);

            // Act
            l.SpawnEntity(e1);
            l.SpawnEntity(e2);
            l.DestroyEntity(e2);
            l.Update(1);

            // We checken of de event handlers geregistreerd zijn door
            // een botsing te simuleren. Als ze NIET botsen, dan is de
            // handler dus successvol ongeregistreerd.

            // Assert
            Assert.AreEqual(new Vector(1, 0), e1.Position);
            Assert.AreEqual(new Vector(10, 0), e2.Position);
        }

        [TestMethod()]
        public void Entity_MoveForVector_ShouldMoveAlongVector()
        {
            // Arrange
            Entity e1 = new EntityWall(0, 0, 10, 10);
            e1.Speed = new Vector(1, 0);

            // Act
            e1.Move(null, 1);

            // Assert
            Assert.AreEqual(e1.X1, 1);
            Assert.AreEqual(0.95, e1.Speed.X);
        }
    }
}