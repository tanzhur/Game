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

        private void PlayerTurn(LogicPlayerPieceMover playerLogic, string messageToPlayer)
        {
            this.pieceMover.PieceMoverStrategy = playerLogic;

            while (true)
            {
                this.ShowGameBoard();
                this.ShowMessageBellowGameBoard(messageToPlayer);

                var command = this.controller.GetCommand();

                if (command == null)
                {
                    this.ShowIllegalMove();
                    continue;
                }

                var pieceToMove = this.pieceMover.FindPieceToMove(command, this.allPieces);

                if (pieceToMove == null)
                {
                    this.ShowIllegalMove();
                    continue;
                }

                var newPieceCoordinates = pieceToMove.GetNewCoordinates(command.Move);

                if (!this.IsPossibleMove(pieceToMove, newPieceCoordinates))
                {
                    this.ShowIllegalMove();
                    continue;
                }

                pieceToMove.Move(newPieceCoordinates);
                break;
            }
            this.CheckGameState();
        }

        private void CheckGameState()
        {
            throw new System.NotImplementedException();
        }

        private void ShowIllegalMove()
        {
            this.ShowMessageBellowGameBoard(GameConstants.IllegalMove, 2);
            this.controller.PressAnyKey();
        }

        private bool IsPossibleMove(IPiece pieceToMove, ICoordinates newPieceCoordinates)
        {
            if (newPieceCoordinates.X<0||
                newPieceCoordinates.X>=this.gameBoard.PlayfieldSize||
                newPieceCoordinates.Y<0 ||
                newPieceCoordinates.Y>= this.gameBoard.PlayfieldSize)
            {
                return false;
            }

            foreach (var list in this.allPieces)
            {
                foreach (var piece in list)
                {
                    if (pieceToMove==piece)
                    {
                        continue;
                    }

                    if (pieceToMove.Coordinates.Equals(piece.Coordinates))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ShowMessageBellowGameBoard(string messageToPlayer, int linesBellowBoard)
        {
            this.renderer.RenderText(messageToPlayer,
                new Coordinates(this.initialGameBoardCoordinates.X,
                    this.initialGameBoardCoordinates.Y + this.gameBoard.Height + linesBellowBoard));
        }

        private void ShowGameBoard()
        {
            this.renderer.Render(this.gameBoard, this.initialGameBoardCoordinates);
        }

        private void ShowGameOutcome()
        {
            throw new System.NotImplementedException();
        }
    }
}