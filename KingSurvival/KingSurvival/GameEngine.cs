namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    using Enums;
    using Interfaces;

    public class GameEngine
    {
        private readonly IRenderer renderer;
        private readonly IController controller;

        private readonly IList<IList<IPiece>> allPieces;

        private readonly IGameBoard gameBoard;
        private readonly ICoordinates initialGameBoardCoordinates;
        private readonly ICoordinates initialMessagesCoordinates;

        private readonly LogicPieceMover pieceMover;
        private readonly LogicPlayerPieceMoverBase playerOneMoveLogic;
        private readonly LogicPlayerPieceMoverBase playerTwoMoveLogic;

        private bool gameIsRunning;
        private bool kingCanMove;
        private int kingMoves;

        public GameEngine(IRenderer renderer, IController controller)
        {
            this.renderer = renderer;
            this.controller = controller;

            this.allPieces = new PlayersAllGamePiecesCreator().CreateGamePieces();

            this.gameBoard = GameBoard.Instance;

            this.pieceMover = new LogicPieceMover();
            this.playerOneMoveLogic = new LogicPlayer1PieceMover();
            this.playerTwoMoveLogic = new LogicPlayer2PieceMover();

            this.initialGameBoardCoordinates = new Coordinates(0, 0);
            this.initialMessagesCoordinates = new Coordinates(this.initialGameBoardCoordinates.X,
                                                              this.initialGameBoardCoordinates.Y + 
                                                              this.gameBoard.Height +
                                                              GameConstants.MessageToPlayerOffset);

            this.gameIsRunning = true;
            this.kingCanMove = true;
            this.kingMoves = 0;
        }

        public void StartGame()
        {
            this.AttachEventsToAllThePieces();

            while (this.gameIsRunning)
            {
                PlayerTurn(this.playerOneMoveLogic, GameConstants.Player1Turn);

                if (!this.gameIsRunning)
                {
                    break;
                }

                PlayerTurn(this.playerTwoMoveLogic, GameConstants.Player2Turn);
            }

            this.ShowGameOutcome();
        }

        private void AttachEventsToAllThePieces()
        {
            foreach (var list in this.allPieces)
            {
                foreach (var piece in list)
                {
                    piece.Moved += this.gameBoard.Notify;
                }
            }
        }

        private void PlayerTurn(LogicPlayerPieceMoverBase playerLogic, string messageToPlayer)
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

                var addKingMove = false;

                var pieceToMove = this.pieceMover.FindPieceToMove(command, this.allPieces, out addKingMove);

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

                if (addKingMove)
                {
                    this.kingMoves++;
                }

                break;
            }

            this.CheckGameState();
        }

        private void CheckGameState()
        {
            // if king reached top or pawns can not move - game over king wins
            if (ArePiecesOnTopOfBoard(this.allPieces[0]) || ArePiecesStuck(this.allPieces[1]))
            {
                this.gameIsRunning = false;
            }

            // if king is stuck - game over
            else if (ArePiecesStuck(this.allPieces[0]))
            {
                this.kingCanMove = false;
                this.gameIsRunning = false;
            }
        }

        private bool ArePiecesOnTopOfBoard(IList<IPiece> piecesToCheck)
        {
            foreach (var piece in piecesToCheck)
            {
                if (piece.Coordinates.Y != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ArePiecesStuck(IList<IPiece> piecesToCheck)
        {
            foreach (var piece in piecesToCheck)
            {
                // checks for all the moves in the enum, if the piece can execute the move is it possible
                foreach (Moves move in (Moves[])Enum.GetValues(typeof(Moves)))
                {
                    if (piece.IsValidMove(move) && this.IsPossibleMove(piece, piece.GetNewCoordinates(move)))
                    {
                        // at least one piece can move - returning
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsPossibleMove(IPiece pieceToMove, ICoordinates newPieceCoordinates)
        {
            if (newPieceCoordinates.X < 0 ||
                newPieceCoordinates.X >= this.gameBoard.PlayfieldSize ||
                newPieceCoordinates.Y < 0 ||
                newPieceCoordinates.Y >= this.gameBoard.PlayfieldSize)
            {
                return false;
            }

            foreach (var list in this.allPieces)
            {
                foreach (var piece in list)
                {
                    if (pieceToMove == piece)
                    {
                        continue;
                    }

                    if (newPieceCoordinates.Equals(piece.Coordinates))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ShowIllegalMove()
        {
            this.ShowMessageBellowGameBoard(GameConstants.IllegalMove);
            this.controller.PressAnyKey();
        }

        private void ShowMessageBellowGameBoard(string messageToPlayer)
        {
            this.renderer.RenderText(GameConstants.BlankMessage, this.initialMessagesCoordinates);

            this.renderer.RenderText(messageToPlayer, this.initialMessagesCoordinates);
        }

        private void ShowGameBoard()
        {
            this.renderer.Render(this.gameBoard, this.initialGameBoardCoordinates);
        }

        private void ShowGameOutcome()
        {
            if (this.kingCanMove)
            {
                ShowMessageBellowGameBoard(string.Format(GameConstants.KingWinsInXTurns, this.kingMoves));
            }
            else
            {
                ShowMessageBellowGameBoard(GameConstants.KingLooses);
            }

            this.controller.PressAnyKey();
        }
    }
}