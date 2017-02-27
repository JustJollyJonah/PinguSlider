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
    public class EntityPlayerTests
    {
        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToLeft_ShouldReturnTrue()
        {
            //Arrange
            bool left = true;
            bool right = false;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreEqual(new Vector(-2, 0).X, player.Speed.X);
            Assert.AreEqual(new Vector(-2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToLeft_ShouldReturnFalse_RightWasSet()
        {
            //Arrange
            bool left = false;
            bool right = true;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(-2, 0).X, player.Speed.X);
            Assert.AreEqual(new Vector(-2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToLeft_ShouldReturnFalse_UpWasSet()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = true;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(-2, 0).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(-2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToLeft_ShouldReturnFalse_DownWasSet()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = true;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(-2, 0).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(-2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToUp_ShouldReturnTrue()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = true;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreEqual(new Vector(0, -2).X, player.Speed.X);
            Assert.AreEqual(new Vector(0, -2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToUp_ShouldReturnFalse_LeftWasSet()
        {
            //Arrange
            bool left = true;
            bool right = false;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(0, -2).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(0, -2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToUp_ShouldReturnFalse_RightWasSet()
        {
            //Arrange
            bool left = false;
            bool right = true;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(0, -2).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(0, -2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToUp_ShouldReturnFalse_DownWasSet()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = true;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreEqual(new Vector(0, -2).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(0, -2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToRight_ShouldReturnTrue()
        {
            //Arrange
            bool left = false;
            bool right = true;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreEqual(new Vector(2, 0).X, player.Speed.X);
            Assert.AreEqual(new Vector(2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToRight_ShouldReturnFalse_LeftWasSet()
        {
            //Arrange
            bool left = true;
            bool right = false;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(2, 0).X, player.Speed.X);
            Assert.AreEqual(new Vector(2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToRight_ShouldReturnFalse_UpWasSet()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = true;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(2, 0).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(2, 0).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToRight_ShouldReturnFalse_DownWasSet()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = true;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(2, 0).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(2, 0).Y, player.Speed.Y);
        }
        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToDown_ShouldReturnTrue()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = true;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreEqual(new Vector(0, 2).X, player.Speed.X);
            Assert.AreEqual(new Vector(0, 2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToDown_ShouldReturnFalse_LeftWasSet()
        {
            //Arrange
            bool left = true;
            bool right = false;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(0, 2).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(0, 2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToDown_ShouldReturnFalse_UpWasSet()
        {
            //Arrange
            bool left = false;
            bool right = false;
            bool up = true;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreEqual(new Vector(0, 2).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(0, 2).Y, player.Speed.Y);
        }

        [TestMethod()]
        public void SetPlayerDirectionTest_ShouldSetDirectionToDown_ShouldReturnFalse_RightWasSet()
        {
            //Arrange
            bool left = false;
            bool right = true;
            bool up = false;
            bool down = false;
            EntityPlayer player = new EntityPlayer(0, 0);

            //Act
            player.SetPlayerDirection(down, up, right, left);

            //Assert
            Assert.AreNotEqual(new Vector(0, 2).X, player.Speed.X);
            Assert.AreNotEqual(new Vector(0, 2).Y, player.Speed.Y);
        }
    }
}