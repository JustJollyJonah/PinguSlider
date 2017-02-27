using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CScherp_Game;
using System.Collections.Generic;

namespace CScherp_GameKBS
{
    [TestClass]
    public class LevelTest
    {
        [TestMethod]
        public void SpawnEntityTest_ShouldPopulateEntityList()
        {
            EntityPlayer player = new EntityPlayer(0,0);
            EntityFinish finish = new EntityFinish(200,200);
            List<Entity> entities = new List<Entity>();
            Game game = new Game();
            Level level = new Level(game, game.Window.GameWidth, game.Window.GameHeight, entities);
            int OldLenght = level.Entities.Count;

            level.Entities.Add(player);
            level.Entities.Add(finish);

            Assert.AreNotEqual(OldLenght, level.Entities.Count);

        }
        [TestMethod]
        public void DestroyEntityTest_ShouldRemoveFromList()
        {
            EntityPlayer player = new EntityPlayer(0, 0);
            EntityFinish finish = new EntityFinish(200, 200);
            List<Entity> entities = new List<Entity>();
            Game game = new Game();
            Level level = new Level(game, game.Window.GameWidth, game.Window.GameHeight, entities);
            level.Entities.Add(player);
            level.Entities.Add(finish);
            int OldLenght = level.Entities.Count;

            level.DestroyEntity(player);

            Assert.IsFalse(level.Entities.Contains(player));
        }
    }
}
