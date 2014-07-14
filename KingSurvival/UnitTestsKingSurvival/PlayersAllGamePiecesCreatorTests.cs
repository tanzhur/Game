namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using System.Collections.Generic;

    [TestClass]
    public class PlayersAllGamePiecesCreatorTests
    {
        [TestMethod]
        [TestCategory("InitializationTests")]
        public void PlayersAllGamePiecesCreatorTestCreateGamePieces()
        {
            var creator = new PlayersAllGamePiecesCreator();
            var list = creator.CreateGamePieces();

            bool firstListIsKing = list[0][0].GetType() == typeof(PieceKing);
            bool secondListIsPawns = true;

            for (int i = 0; i < list[1].Count; i++)
            {
                if (list[1][i].GetType() != typeof(PiecePawn))
                {
                    secondListIsPawns = false;
                }
            }

            bool result = ((list.Count == 2) && (list[0].Count == 1) && (list[1].Count == 4) && firstListIsKing && secondListIsPawns);

            Assert.IsTrue(result);
        }
    }
}
