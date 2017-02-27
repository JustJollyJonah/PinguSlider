using Microsoft.VisualStudio.TestTools.UnitTesting;
using CScherp_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CScherp_Game.Tests
{
    [TestClass()]
    public class EditorTests
    {
        [TestMethod()]
        public void DeleteEntityFromChoosenListTest_DeletesPlayerEntity_ShouldReturnTrue()
        {
            //Arrange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityFinish selectedEntity = new EntityFinish(88, 92);
            choosenEntities.Add(new EntityFinish(480, 178));
            choosenEntities.Add(new EntityFinish(275, 218));
            choosenEntities.Add(new EntityFinish(97, 243));
            choosenEntities.Add(new EntityPlayer(88, 92));
            choosenEntities.Add(new EntityFinish(331, 104));

            bool thereIsNotAPlayerEntity = true;
            int playerCount = 0;

            //Act
            choosenEntities = editor.DeleteEntityFromChoosenList(selectedEntity, choosenEntities);

            //Assert
            foreach (Entity entity in choosenEntities)
            {
                if (entity.ToString() == "EntityPlayer")
                    thereIsNotAPlayerEntity = false;
            }
            
            Assert.IsTrue((thereIsNotAPlayerEntity), choosenEntities.Count.ToString());
        }

        [TestMethod()]
        public void DeleteEntityFromChoosenListTest_DeletesPlayerEntity_WithEmptyListShouldBeEqual()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityFinish selectedEntity = new EntityFinish(88, 92);

            //Act 
            choosenEntities = editor.DeleteEntityFromChoosenList(selectedEntity, choosenEntities);

            //Assert
            Assert.AreEqual(0, choosenEntities.Count);
        }

        [TestMethod()]
        public void DeleteEntityFromChoosenListTest_DeletesNothing_ShouldReturnTrue()
        {
            //Arrange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityFinish selectedEntity = new EntityFinish(0, 0);
            choosenEntities.Add(new EntityFinish(480, 178));
            choosenEntities.Add(new EntityFinish(275, 218));
            choosenEntities.Add(new EntityFinish(97, 243));
            choosenEntities.Add(new EntityPlayer(88, 92));
            choosenEntities.Add(new EntityFinish(331, 104));

            bool thereIsNotAPlayerEntity = true;
            int playerCount = 0;

            //Act
            choosenEntities = editor.DeleteEntityFromChoosenList(selectedEntity, choosenEntities);

            //Assert
            foreach (Entity entity in choosenEntities)
            {
                if (entity.ToString() == "EntityPlayer")
                    thereIsNotAPlayerEntity = false;
            }

            Assert.AreEqual(5 , choosenEntities.Count);
        }

        [TestMethod()]
        public void AddEntity_ShouldAddFinishEntity()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityFinish selectedEntity = new EntityFinish(20, 20);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();

            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount);

            //Assert
            Assert.AreEqual("EntityFinish", choosenEntities[0].ToString());
        }

        [TestMethod()]
        public void AddEntity_ShouldAddPlayerEntity()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityPlayer selectedEntity = new EntityPlayer(20, 20);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();
            
            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount);

            //Assert
            Assert.AreEqual("EntityPlayer", choosenEntities[0].ToString());
        }

        [TestMethod()]
        public void AddEntity_ShouldAddStaticObstacleEntity()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityObstacleStatic selectedEntity = new EntityObstacleStatic(20, 20);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();

            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount);

            //Assert
            Assert.AreEqual("EntityObstacleStatic", choosenEntities[0].ToString());
        }

        [TestMethod()]
        public void AddEntity_ShouldAddMovingObstacleEntity_WithFourParameters()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityObstacleMoving selectedEntity = new EntityObstacleMoving(20, 20, 0, 5);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();

            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount);

            //Assert
            Assert.AreEqual("EntityObstacleMoving", choosenEntities[0].ToString());
        }

        [TestMethod()]
        public void AddEntity_ShouldAddMovingObstacleEntity_WithFiveParameters()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityObstacleMoving selectedEntity = new EntityObstacleMoving(20, 20, 0, 5);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();
            String direction = "0";

            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount, direction);

            //Assert
            Assert.AreEqual("EntityObstacleMoving", choosenEntities[0].ToString());
        }

        [TestMethod()]
        public void AddEntity_ShouldAddMovingObstacleEntity_WithHorizontalDirection()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityObstacleMoving selectedEntity = new EntityObstacleMoving(20, 20, 0, 5);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();
            String direction = "0";

            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount, direction);

            //Assert
            Assert.AreEqual(new EntityObstacleMoving(20, 20, 2, 0).Speed, choosenEntities[0].Speed);
        }

        [TestMethod()]
        public void AddEntity_ShouldAddMovingObstacleEntity_WithVerticalDirection()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> choosenEntities = new List<Entity>();
            EntityObstacleMoving selectedEntity = new EntityObstacleMoving(20, 20, 0, 5);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();
            String direction = "1";

            //Act
            editor.AddEntity(selectedEntity, ref choosenEntities, selectedEntity, ref playerCount, direction);

            //Assert
            Assert.AreEqual(new EntityObstacleMoving(20, 20, 0, 2).Speed, choosenEntities[0].Speed);
        }

        [TestMethod()]
        public void AddEntity_ShouldAddMovingObstacleEntity_WithNoDirection()
        {
            //Arrange
            Editor editor = new Editor(null);
            List<Entity> chosenEntities = new List<Entity>();
            EntityObstacleMoving selectedEntity = new EntityObstacleMoving(20, 20, 0, 0);
            int playerCount = 0;
            TextBox messageTextEditor = new TextBox();

            //Act
            editor.AddEntity(selectedEntity, ref chosenEntities, selectedEntity, ref playerCount);

            //Assert
            Assert.AreEqual(new EntityObstacleMoving(20, 20, 0, 0).Speed, chosenEntities[0].Speed);
        }

        [TestMethod()]
        public void AddEntity_ShouldAddPlayerEntity_ShoudlReturnAreNotEqualBecauseThereAlreadyIsAPlayer()
        {
            //Arange
            Editor editor = new Editor(null);
            List<Entity> chosenEntities = new List<Entity>();
            EntityPlayer selectedEntity = new EntityPlayer(0, 0);
            int playerCount = 1;
            TextBox messageTextEditor = new TextBox();

            //Act
            editor.AddEntity(selectedEntity, ref chosenEntities, selectedEntity, ref playerCount);

            //Assert
            Assert.AreNotEqual(1, chosenEntities.Count);
        }
    }
}