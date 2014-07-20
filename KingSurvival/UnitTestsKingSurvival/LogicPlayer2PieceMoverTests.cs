
namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using KingSurvival.Enums;
    using KingSurvival.Interfaces;
    using System.Collections.Generic;

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
