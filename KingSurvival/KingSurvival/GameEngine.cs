namespace KingSurvival
{
    using System.Collections.Generic;
    using System.Threading;

    using Enums;
    using Interfaces;

    public class GameEngine
    {
        private readonly IRenderer renderer;
        private readonly IController controller;
        private readonly IList<IList<IPiece>> allPieces;
        private readonly IGameBoard gameBoard;
        private readonly ICoordinates initialGameBoardCoordinates;
        private readonly LogicPieceMover pieceMover;
        private readonly LogicPlayerPieceMover player1MoveLogic,
                                               player2MoveLogic;

        private bool gameIsRunning;
        private bool kingIsStuck;
        private int kingMoves;

        public GameEngine(IRenderer renderer, IController controller)
        {
            this.renderer = renderer;
            this.controller = controller;

            this.allPieces = new PlayersAllGamePiecesCreator().CreateGamePieces();
            this.gameBoard = new GameBoard();

            this.player1MoveLogic = new LogicPlayerPieceMover(0);
            this.player2MoveLogic = new LogicPlayerPieceMover(1);
            this.initialGameBoardCoordinates = new Coordinates(0, 0);
            this.gameIsRunning = true;
        }


        internal void StartGame()
        {
            while (this.gameIsRunning)
            {
                PlayerTurn(this.player1MoveLogic, GameConstants.player1Turn);
                if (!this.gameIsRunning)
                {
                    break;
                }
                PlayerTurn(this.player2MoveLogic, GameConstants.player1Turn);
            }

            this.ShowGameOutcome();
        }

        private void PlayerTurn(LogicPlayerPieceMover logicPlayerPieceMover, string p)
        {
            throw new System.NotImplementedException();
        }

        private void ShowGameOutcome()
        {
            throw new System.NotImplementedException();
        }
    }
}