namespace UnitTestsKingSurvival.Game
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.ConsoleClient.Controller;

    using KingSurvival.Game.Enums;
    using KingSurvival.Game.GameInitializer;
    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.Interfaces;
    using KingSurvival.Game.Logic;

    [TestClass]
    public class LogicPlayer1PieceMoverTests
    {
        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void LogicPlayer1PieceMoverMethodFindPieceToMoveTestWithValidInput()
        {
            LogicPieceMover mover = new LogicPieceMover();
            mover.PieceMoverStrategy = new LogicPlayer1PieceMover();

            var creator = new PlayersAllGamePiecesCreator();
            IList<IList<IPiece>> list = creator.CreateGamePieces();
            ICommand command = new Command('K', Moves.UpLeft);
            bool score = false;

            IPiece resultPiece = mover.FindPieceToMove(command, list, out score);

            bool result = (resultPiece.GetType() == typeof(PieceKing) && score);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void LogicPlayer1PieceMoverMethodFindPieceToMoveTestInvalidInputWithWrongCharForCommand()
        {
            LogicPieceMover mover = new LogicPieceMover();
            mover.PieceMoverStrategy = new LogicPlayer1PieceMover();

            var creator = new PlayersAllGamePiecesCreator();
            IList<IList<IPiece>> list = creator.CreateGamePieces();
            ICommand command = new Command('A', Moves.UpLeft);
            bool score = false;

            IPiece resultPiece = mover.FindPieceToMove(command, list, out score);

            bool result = (resultPiece == null && !score);

            Assert.IsTrue(result);
        }
    }
}
