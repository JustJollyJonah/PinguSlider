using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CScherp_Game;
using System.Linq;
using System.Threading;

namespace CScherp_GameKBS
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GameTests_WhenGameReset_LevelIsNotTheSame()
        {
            
            Game game = new Game();
            game.Level.Player.Position = new CScherp_Game.Vector(100, 100);
            Level levelOriginal = game.Level;

            game.Reset();

            Level levelNew = game.Level;
            Assert.AreNotEqual(levelOriginal, levelNew, "Reset worked");
        }

        [TestMethod]
        public void CheckPauseGame_isTrue()
        {

            // Arrange
            Game game = new Game();
            // Act
            game.gamePaused = true;

            // assert
            Assert.AreEqual(game.gamePaused, true, "Test succeeded, game paused");
            }
        [TestMethod]
        public void CheckUnpausedGame_isTrue()
        {
            // Arrange
            Game game = new Game();
            // Act
            game.gamePaused = false;

            // assert
            Assert.AreEqual(game.gamePaused, false, "Test succeeded, game paused");
        }
        [TestMethod]
        public void CheckTimeIsRunning_isNotNull()
        {
            // Arrange
            Game game = new Game();
            // Act
          long time = game.timerScoreView.stopwatch.ElapsedMilliseconds;

            // assert
            Assert.IsNotNull(time, "Test succeeded, time is running");
        }
        [TestMethod]
        public void CheckTimeIsStoppedWhenGamePaused_isNotNull()
        {
            // Arrange
            Game game = new Game();
            // Act
            long beforeTime = game.timerScoreView.stopwatch.ElapsedMilliseconds / 1000;
            game.PauseGame();
            Thread.Sleep(2000);
            long afterTime = game.timerScoreView.stopwatch.ElapsedMilliseconds / 1000;

            // assert
            Assert.AreEqual(beforeTime,afterTime, "Test succeeded, time stopped");
        }
        [TestMethod]
        public void CheckTimeIsRunningWhenGamUnpaused_isNotNull()
        {
            // Arrange
            Game game = new Game();
            // Act
            long beforeTime = game.timerScoreView.stopwatch.ElapsedMilliseconds;
            game.PauseGame();
            game.UnpauseGame();
            Thread.Sleep(2000);
            long afterTime = game.timerScoreView.stopwatch.ElapsedMilliseconds;
            // assert
            Assert.AreNotEqual(beforeTime, afterTime, "Test succeeded, time stopped");
        }
        [TestMethod]
        public void CheckTimeIsRestartedWhenGamRestarts_isNull()
        {
            // Arrange
            Game game = new Game();
            // Act
            game.Reset();
            long time = game.timerScoreView.stopwatch.ElapsedMilliseconds;
            
            // assert
            Assert.IsTrue(time < 1, "Test succeeded, time stopped");
        }
        [TestMethod]
        public void GameStart_ShouldShowWindow()
        {
            // Arrange
            Game game = new Game();
            // Act
            game.Start();

            // assert
            Assert.IsTrue(game.Window.Visible);
            game.Hide();
        }
        [TestMethod]
        public void GameHide_ShouldHideWindow()
        {
            // Arrange
            Game game = new Game();
            // Act
            game.Start();
            game.Hide();

            // assert
            Assert.IsFalse(game.Window.Visible);
        }
        [TestMethod]
        public void GameSetLevel_ShouldChangePathToLevelXml()
        {
            // Arrange
            Game game = new Game();
            String oldPath = game.SelectedLevelPath;
            String TestPath = "something";
            // Act
            game.SetLevel(TestPath);
            String newPath = game.SelectedLevelPath;

            // assert
            Assert.AreNotEqual(oldPath, newPath);
        }
    }
}

