namespace UnitTestsKingSurvival.Game
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.ConsoleClient.Controller;

    using KingSurvival.Game.Enums;
    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.GameInitializer;
    using KingSurvival.Game.Interfaces;
    using KingSurvival.Game.Logic;

    [TestClass]
    public class LogicPlayer2PieceMoverTests
    {
        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void LogicPlayer2PieceMoverMethodFindPieceToMoveTestWithValidInput()
        {
            LogicPieceMover mover = new LogicPieceMover();
            mover.PieceMoverStrategy = new LogicPlayer2PieceMover();

            var creator = new PlayersAllGamePiecesCreator();
            IList<IList<IPiece>> list = creator.CreateGamePieces();
            ICommand command = new Command('A', Moves.DownLeft);
            bool score = false;

            IPiece resultPiece = mover.FindPieceToMove(command, list, out score);

            bool result = (resultPiece.GetType() == typeof(PiecePawn));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void LogicPlayer2PieceMoverMethodFindPieceToMoveTestInvalidInputWithWrongCharForCommand()
        {
            LogicPieceMover mover = new LogicPieceMover();
            mover.PieceMoverStrategy = new LogicPlayer2PieceMover();
            var creator = new PlayersAllGamePiecesCreator();
            IList<IList<IPiece>> list = creator.CreateGamePieces();
            ICommand command = new Command('K', Moves.DownLeft);
            bool score = false;

            IPiece resultPiece = mover.FindPieceToMove(command, list, out score);

            bool result = (resultPiece == null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void LogicPlayer2PieceMoverMethodFindPieceToMoveTestInvalidInputWithWrongMoveForCommand()
        {
            LogicPieceMover mover = new LogicPieceMover();
            mover.PieceMoverStrategy = new LogicPlayer2PieceMover();
            var creator = new PlayersAllGamePiecesCreator();
            IList<IList<IPiece>> list = creator.CreateGamePieces();
            ICommand command = new Command('A', Moves.UpLeft);
            bool score = false;

            IPiece resultPiece = mover.FindPieceToMove(command, list, out score);

            bool result = (resultPiece == null);

            Assert.IsTrue(result);
        }
    }
}
