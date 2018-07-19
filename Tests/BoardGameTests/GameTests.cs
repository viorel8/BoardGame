using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardGame;

namespace BoardGameTests
{
    [TestClass]
    public class GameTests
    {
        private GameSettings settings;

        private GameLogic gameLogic;

        public GameTests()
        {
            settings = new GameSettings() { BoardWidth = 5, BoardHeight = 5 };

            var gameLogic = new GameLogic(settings);
        }

        [TestMethod]
        public void GameEngine_initialise()
        {
            //Arrange
            var engine = new GameEngine(gameLogic);

            //Act
            engine.Start();

            //Assert
            Assert.IsInstanceOfType(engine, typeof(IGameEngine));
        }
    }
}
