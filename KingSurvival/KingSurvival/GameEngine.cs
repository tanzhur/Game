namespace KingSurvival
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    /// <summary>
    /// Engine for KingSurvival implementation
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// The video renderer used by the game - passed on instance creation.
        /// </summary>
        private readonly IRenderer renderer;

        /// <summary>
        /// The controller used by the game - passed on instance creation.
        /// </summary>
        private readonly IController controller;

        /// <summary>
        /// List of lists holding all pieces in the game - each list represents a collection of pieces for each player.
        /// </summary>
        private readonly IList<IList<IPiece>> allPieces;

        /// <summary>
        /// IGameBoard that tracks the pieces and shows their position to the player.
        /// </summary>
        private readonly IGameBoard gameBoard;

        /// <summary>
        /// The coordinates at which the game board will be displayed.
        /// </summary>
        private readonly ICoordinates initialGameBoardCoordinates;

        /// <summary>
        /// The coordinates at which the game messages to the player will be displayed.
        /// </summary>
        private readonly ICoordinates initialMessagesCoordinates;

        /// <summary>
        /// The logic holder that moves the pieces of the current player.
        /// </summary>
        private readonly LogicPieceMover pieceMover;

        /// <summary>
        /// The logic for moving the pieces if it is player 1 turn.
        /// </summary>
        private readonly LogicPlayerPieceMoverBase playerOneMoveLogic;

        /// <summary>
        /// The logic for moving the pieces if it is player 2 turn.
        /// </summary>
        private readonly LogicPlayerPieceMoverBase playerTwoMoveLogic;

        /// <summary>
        /// Holds information if the game should continue to ask players for commands.
        /// </summary>
        private bool gameIsRunning;

        /// <summary>
        /// Holds if the king has a possible move - if he is not stuck by the pawns or the size of the game board.
        /// </summary>
        private bool kingCanMove;

        /// <summary>
        /// Counts the king moves.
        /// </summary>
        private int kingMoves;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class holding the logic for each of the games.
        /// </summary>
        /// <param name="renderer">The video renderer used by the game.</param>
        /// <param name="controller">The controller used by the game.</param>
        public GameEngine(IRenderer renderer, IController controller)
        {
            this.renderer = renderer;
            this.controller = controller;

            this.allPieces = new PlayersAllGamePiecesCreator().CreateGamePieces();

            this.gameBoard = GameBoard.Instance;

            this.pieceMover = new LogicPieceMover();
            this.playerOneMoveLogic = new LogicPlayer1PieceMover();
            this.playerTwoMoveLogic = new LogicPlayer2PieceMover();

            this.initialGameBoardCoordinates = new Coordinate(0, 0);
            this.initialMessagesCoordinates = new Coordinate(
                                              this.initialGameBoardCoordinates.X,
                                              this.initialGameBoardCoordinates.Y + this.gameBoard.Height + GameConstants.MessageToPlayerOffset);

            this.gameIsRunning = true;
            this.kingCanMove = true;
            this.kingMoves = 0;
        }

        /// <summary>
        /// Initializes the game loop and repeats it as long as one of the players wins.
        /// </summary>
        public void StartGame()
        {
            // the game board should know if a piece moves.
            this.AttachEventsToAllThePieces();

            // the main game loop.
            while (this.gameIsRunning)
            {
                // executes a player 1 move by attaches logic for player 1.
                this.PlayerTurn(this.playerOneMoveLogic, GameConstants.Player1Turn);

                // checks if player 1 didnt end the game - the check for player 2 is done at the entry of the loop.
                if (!this.gameIsRunning)
                {
                    // game is over - break the loop and show game result.
                    break;
                }

                // executes a player 1 move by attaches logic for player 2.
                this.PlayerTurn(this.playerTwoMoveLogic, GameConstants.Player2Turn);
            }

            this.ShowGameOutcome();
        }

        /// <summary>
        /// Attaches the game board Notify method to all the moved event of all the pieces.
        /// </summary>
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

        /// <summary>
        /// Ask player to make a move.
        /// </summary>
        /// <param name="playerLogic">Player strategy to follow.</param>
        /// <param name="messageToPlayer">Player specific message.</param>
        private void PlayerTurn(LogicPlayerPieceMoverBase playerLogic, string messageToPlayer)
        {
            // change the logic of the piece mover with the passed one
            this.pieceMover.PieceMoverStrategy = playerLogic;

            while (true)
            {
                // ask for command
                this.ShowGameBoard();
                this.ShowMessageBellowGameBoard(messageToPlayer);

                // gets a command via the game controller
                var command = this.controller.GetCommand();

                // command is not valid or null - show error and ask again
                if (command == null)
                {
                    this.ShowIllegalMove();
                    continue;
                }

                var addKingMove = false;

                // finds a piece to move depending on the logic passed to the piece mover
                var pieceToMove = this.pieceMover.FindPieceToMove(command, this.allPieces, out addKingMove);

                // and command is valid for any piece
                if (pieceToMove == null)
                {
                    this.ShowIllegalMove();
                    continue;
                }

                // gets the future coordinates of the piece if it executes the current move
                var newPieceCoordinates = pieceToMove.GetNewCoordinates(command.Move);

                // and command is valid for current board positioning
                if (!this.IsPossibleMove(pieceToMove, newPieceCoordinates))
                {
                    this.ShowIllegalMove();
                    continue;
                }

                // move the piece via its method so that the event can be fired.
                pieceToMove.Move(newPieceCoordinates);

                // if the PieceMoverStrategy says that a king move should be added - add one.
                if (addKingMove)
                {
                    this.kingMoves++;
                }

                break;
            }

            // checks if the game is over
            this.CheckGameState();
        }

        /// <summary>
        /// Checks if the game can progress.
        /// </summary>
        private void CheckGameState()
        {
            // if king reached top or pawns can not move - game over king wins
            if (this.ArePiecesOnTopOfBoard(this.allPieces[0]) || this.ArePiecesStuck(this.allPieces[1]))
            {
                this.gameIsRunning = false;
            }
            else if (this.ArePiecesStuck(this.allPieces[0]))
            {
                // if king is stuck - game over
                this.kingCanMove = false;
                this.gameIsRunning = false;
            }
        }

        /// <summary>
        /// Checks if passed pieces have reached the top of the board - used primary as checker if the king wins in this settings.
        /// </summary>
        /// <param name="piecesToCheck">The pieces to be checked</param>
        /// <returns>The answer if there is at least one piece that can move</returns>
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

        /// <summary>
        /// Shows if all the pieces can not perform any moves
        /// </summary>
        /// <param name="piecesToCheck">The list of pieces to check</param>
        /// <returns>If there is at least one piece that can move</returns>
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

        /// <summary>
        /// Check if piece can move in the current playground.
        /// </summary>
        /// <param name="pieceToMove">Piece to move.</param>
        /// <param name="newPieceCoordinates">Desired move coordinates.</param>
        /// <returns>If the current move is a possible one</returns>
        private bool IsPossibleMove(IPiece pieceToMove, ICoordinates newPieceCoordinates)
        {
            // checks if the piece will leave the game board.
            if (newPieceCoordinates.X < 0 ||
                newPieceCoordinates.X >= this.gameBoard.PlayfieldSize ||
                newPieceCoordinates.Y < 0 ||
                newPieceCoordinates.Y >= this.gameBoard.PlayfieldSize)
            {
                return false;
            }

            // checks if the piece is overlapping with another piece.
            foreach (var list in this.allPieces)
            {
                foreach (var piece in list)
                {
                    // the piece can not overlap with itself.
                    if (pieceToMove == piece)
                    {
                        continue;
                    }

                    // the piece overlaps with another piece.
                    if (newPieceCoordinates.Equals(piece.Coordinates))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Notifies the player that the current move is illegal.
        /// </summary>
        private void ShowIllegalMove()
        {
            this.ShowMessageBellowGameBoard(GameConstants.IllegalMove);
            this.controller.PressAnyKey();
        }

        /// <summary>
        /// Print notification messages for current player.
        /// </summary>
        /// <param name="messageToPlayer">message for current player</param>
        private void ShowMessageBellowGameBoard(string messageToPlayer)
        {
            this.renderer.RenderText(GameConstants.BlankMessage, this.initialMessagesCoordinates);

            this.renderer.RenderText(messageToPlayer, this.initialMessagesCoordinates);
        }

        /// <summary>
        /// Shows the game board with all the pieces on it.
        /// </summary>
        private void ShowGameBoard()
        {
            this.renderer.Render(this.gameBoard, this.initialGameBoardCoordinates);
        }

        /// <summary>
        /// Shows the end game result when the game is over.
        /// </summary>
        private void ShowGameOutcome()
        {
            if (this.kingCanMove)
            {
                this.ShowMessageBellowGameBoard(string.Format(GameConstants.KingWinsInXTurns, this.kingMoves));
            }
            else
            {
                this.ShowMessageBellowGameBoard(GameConstants.KingLooses);
            }

            this.controller.PressAnyKey();
        }
    }
}