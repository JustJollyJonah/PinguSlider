using Microsoft.VisualStudio.TestTools.UnitTesting;
using CScherp_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace CScherp_Game.Tests
{
    [TestClass()]
    public class XmlParserTests
    {

        [TestMethod()]
        public void shouldReturnFalseWhenListDoesNotContainEntityFinish()
        {
            //arrange
            List<Entity> entitities = new List<Entity>();
            entitities.Add(new EntityObstacleMoving(10, 10));
            entitities.Add(new EntityPlayer(10, 10));

            //act
            XmlParser parser = new XmlParser();
            var actual = parser.ValidateEntityList(entitities);

            //assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void shouldReturnFalseWhenListDoesNotContainEntityPlayer()
        {
            //arrange
            List<Entity> entitities = new List<Entity>();
            entitities.Add(new EntityFinish(10, 10));
            entitities.Add(new EntityObstacleMoving(10, 10));

            //act
            XmlParser parser = new XmlParser();
            var actual = parser.ValidateEntityList(entitities);

            //assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void shouldReturnTrueWhenListContainsPlayerStartAndFinish()
        {
            //arrange
            List<Entity> entitities = new List<Entity>();
            entitities.Add(new EntityFinish(10, 10));
            entitities.Add(new EntityPlayer(10, 10));

            //act
            XmlParser parser = new XmlParser();
            var actual = parser.ValidateEntityList(entitities);

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ShouldReturnNullWhenNodeIsMissingVitalAttributes()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity  x=\"10\" y=\"10\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");
            
            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void ShouldReturnEntityFinishWhenNodeAttributeTypeIsFinish()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"finish\" x=\"10\" y=\"10\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(typeof(EntityFinish), actual.GetType());
        }

        [TestMethod()]
        public void ShouldReturnEntityPlayerWhenNodeAttributeTypeIsPlayer()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"player\" x=\"10\" y=\"10\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(typeof(EntityPlayer), actual.GetType());
        }

        [TestMethod()]
        public void ShouldReturnEntityObstacleMovingWhenNodeAttributeTypeIsObstacle1()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"obstacle1\" x=\"10\" y=\"10\" vx=\"10\" vy=\"0\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(typeof(EntityObstacleMoving), actual.GetType());
        }

        [TestMethod()]
        public void ShouldReturnEntityObstacleStaticWhenNodeAttributeTypeIsObstacle2()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"obstacle2\" x=\"10\" y=\"10\" movSpeed=\"10\" movType=\"0\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(typeof(EntityObstacleStatic), actual.GetType());
        }

        [TestMethod()]
        public void ShouldReturnNullWhenNodeAttributeTypeIsUnknown()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"obstacle3\" x=\"10\" y=\"10\" movSpeed=\"10\" movType=\"0\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void ShouldReturnNullWhenNoEntitiesInXml()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<object></object>");
            XmlParser parser = new XmlParser();
            parser.levelDocument = doc;

            //act
            var actual = parser.PopulateEntities();

            //assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void ShouldReturnEntityListWhenEverythingisOK()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<level><entity type=\"player\" x=\"10\" y=\"10\"></entity><entity type=\"finish\" x=\"10\" y=\"10\"></entity></level>");
            XmlParser parser = new XmlParser();
            parser.levelDocument = doc;
            //act
            var actual = parser.PopulateEntities();

            //assert
            Assert.AreEqual(typeof(List<Entity>), actual.GetType());
        }


        [TestMethod()]
        public void shouldReturnNullWhenObstacleEntityIsMissingSpeed()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"obstacle1\" x=\"10\" y=\"10\" movType=\"0\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void shouldReturnNullWhenObstacleEntityIsMissingMovementType()
        {
            //arrange
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<entity type=\"obstacle1\" x=\"10\" y=\"10\" movSpeed=\"0\"></entity>");
            XmlParser parser = new XmlParser();
            XmlNode node = doc.SelectSingleNode("//entity");

            //act
            var actual = parser.getEntityFromNode(node);

            //assert
            Assert.AreEqual(null, actual);
        }


        [TestMethod()]
        public void ShouldReturnFalseWhenListContainsMultiplePlayers()
        {
            //arrange
            List<Entity> entitities = new List<Entity>();
            entitities.Add(new EntityFinish(10, 10));
            entitities.Add(new EntityPlayer(10, 10));
            entitities.Add(new EntityPlayer(10, 10));


            //act
            XmlParser parser = new XmlParser();
            var actual = parser.ValidateEntityList(entitities);

            //assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void IfXmlIsResourceShouldBeTrue()
        {
            //arrange en act
            XmlParser parser = new XmlParser("<level></level>", null);

            //assert
            Assert.IsTrue(parser.isResource);

        }











    }
}