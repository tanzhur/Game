namespace KingSurvival
{
    using System;
    using System.Linq;

    // original code
    public class KingSurvival
    {
        // Фигура, пази позиция (ред, колона)
        public struct Piece
        {
            private int row;
            private int col;

            public Piece(int currentRow, int currentCol)
                : this()
            {
                this.Row = currentRow;
                this.Col = currentCol;
            }

            public int Row
            {
                get
                {
                    return this.row;
                }

                set
                {
                    this.row = value;
                }
            }

            public int Col
            {
                get
                {
                    return this.col;
                }

                set
                {
                    this.col = value;
                }
            }
        }

        public static void Main(string[] args)
        {
            const int PawnAStartRow = 0;
            const int PawnAStartColumn = 0;
            const int PawnBStartRow = 0;
            const int PawnBStartColumn = 2;
            const int PawnCStartRow = 0;
            const int PawnCStartColumn = 4;
            const int PawnDStartRow = 0;
            const int PawnDStartColumn = 6;
            const int KingStartRow = 7;
            const int KingStartColumn = 3;
            
            Piece pawnA = new Piece(PawnAStartRow, PawnAStartColumn);
            Piece pawnB = new Piece(PawnBStartRow, PawnBStartColumn);
            Piece pawnC = new Piece(PawnCStartRow, PawnCStartColumn);
            Piece pawnD = new Piece(PawnDStartRow, PawnDStartColumn);

            Piece king = new Piece(KingStartRow, KingStartColumn);
            bool isGameOver = false;

            // Пази последователноста на хода
            // ако е четно - пешките са на ход
            // ако е нечетно - царя е на ход
            int turnSuccession = 1;
            while (!isGameOver)
            {
                bool isValidMove;
                do
                {
                    Console.Clear();
                    PrintGameBoard(pawnA, pawnB, pawnC, pawnD, king);

                    isValidMove = IsMoveDone(turnSuccession, ref pawnA, ref pawnB, ref pawnC, ref pawnD, ref king);
                }
                while (!isValidMove);

                isGameOver = IsThereAWinner(turnSuccession, pawnA, pawnB, pawnC, pawnD, king);
                turnSuccession++;
            }
        }

        // Методът се вика след всеки изигран ход
        // Проверява дали има победител в този момент
        private static bool IsThereAWinner(int turn, Piece pawnA, Piece pawnB, Piece pawnC, Piece pawnD, Piece king)
        {
            const int PlayfieldSize = 7;

            if (turn % 2 == 1)
            {
                // Дали Царя не е достигнал до победното поле
                if (king.Row == 0)
                {
                    Console.Clear();
                    PrintGameBoard(pawnA, pawnB, pawnC, pawnD, king);
                    Console.WriteLine("King wins in {0} turns.", (turn / 2) + 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // Дали Царя няма къде да мърда -> загубил е
                // Следват булеви променливи, които пазят въможните ходове на Царя
                bool KUL = true;
                bool KUR = true;
                bool KDL = true;
                bool KDR = true;

                if (king.Row == 0)
                {
                    KUL = false;
                    KUR = false;
                }
                else if (king.Row == PlayfieldSize)
                {
                    KDL = false;
                    KDR = false;
                }

                if (king.Col == 0)
                {
                    KUL = false;
                    KDL = false;
                }
                else if (king.Col == PlayfieldSize)
                {
                    KUR = false;
                    KDR = false;
                }

                if (!IsPositionEmpty(king.Row - 1, king.Col - 1, pawnA, pawnB, pawnC, pawnD))
                {
                    KUL = false;
                }

                if (!IsPositionEmpty(king.Row - 1, king.Col + 1, pawnA, pawnB, pawnC, pawnD))
                {
                    KUR = false;
                }

                if (!IsPositionEmpty(king.Row + 1, king.Col - 1, pawnA, pawnB, pawnC, pawnD))
                {
                    KDL = false;
                }

                if (!IsPositionEmpty(king.Row + 1, king.Col + 1, pawnA, pawnB, pawnC, pawnD))
                {
                    KDR = false;
                }

                if (!KDR && !KDL && !KUL && !KUR)
                {
                    Console.Clear();
                    PrintGameBoard(pawnA, pawnB, pawnC, pawnD, king);
                    Console.WriteLine("King loses.");
                    return true;
                }

                // Проверка дали пешките няма къде да мърдат
                // Тогава Царят печели!
                if (!HasPawnPosibleMoves(pawnA, pawnB, pawnC, pawnD, king) && !HasPawnPosibleMoves(pawnB, pawnA, pawnC, pawnD, king) && !HasPawnPosibleMoves(pawnC, pawnA, pawnB, pawnD, king) && !HasPawnPosibleMoves(pawnD, pawnA, pawnB, pawnC, king))
                {
                    Console.Clear();
                    PrintGameBoard(pawnA, pawnB, pawnC, pawnD, king);
                    Console.WriteLine("King wins in {0} turns.", turn / 2);
                    return true;
                }

                return false;
            }
        }

        private static bool HasPawnPosibleMoves(Piece pawn, Piece piece1, Piece piece2, Piece piece3, Piece piece4)
        {
            const int PlayfieldSize = 7;

            if (pawn.Row == PlayfieldSize)
            {
                return false;
            }
            else if (pawn.Col > 0 && pawn.Col < PlayfieldSize)
            {
                if (!IsPositionEmpty(pawn.Row + 1, pawn.Col + 1, piece1, piece2, piece3, piece4) &&

                    !IsPositionEmpty(pawn.Row + 1, pawn.Col - 1, piece1, piece2, piece3, piece4))
                {
                    return false;
                }
            }
            else if (pawn.Col == 0)
            {
                if (!IsPositionEmpty(pawn.Row + 1, pawn.Col + 1, piece1, piece2, piece3, piece4))
                {
                    return false;
                }
            }
            else if (pawn.Col == PlayfieldSize)
            {
                if (!IsPositionEmpty(pawn.Row + 1, pawn.Col - 1, piece1, piece2, piece3, piece4))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsMoveDone(int turn, ref Piece pawnA, ref Piece pawnB, ref Piece pawnC, ref Piece pawnD, ref Piece king)
        {
            const int PlayfieldSize = 7;

            if (turn % 2 == 1)
            {
                Console.Write("King’s turn: ");
                string move = Console.ReadLine();
                switch (move)
                {
                    case "KUL":
                        if (king.Col > 0 && king.Row > 0 && IsPositionEmpty(king.Row - 1, king.Col - 1, pawnA, pawnB, pawnC, pawnD))
                        {
                            king.Col--;
                            king.Row--;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "KUR":
                        if (king.Col < PlayfieldSize && king.Row > 0 && IsPositionEmpty(king.Row - 1, king.Col + 1, pawnA, pawnB, pawnC, pawnD))
                        {
                            king.Col++;
                            king.Row--;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "KDL":
                        if (king.Col > 0 && king.Row < PlayfieldSize && IsPositionEmpty(king.Row + 1, king.Col - 1, pawnA, pawnB, pawnC, pawnD))
                        {
                            king.Col--;
                            king.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "KDR":
                        if (king.Col < PlayfieldSize && king.Row < PlayfieldSize && IsPositionEmpty(king.Row + 1, king.Col + 1, pawnA, pawnB, pawnC, pawnD))
                        {
                            king.Col++;
                            king.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");

                            Console.ReadKey();
                            return false;
                        }

                        break;
                    default:
                        Console.Write("Illegal move!");
                        Console.ReadKey();
                        return false;
                }
            }
            else
            {
                Console.Write("Pawn's turn: ");

                string move = Console.ReadLine();
                switch (move)
                {
                    case "ADL":
                        if (pawnA.Col > 0 && pawnA.Row < PlayfieldSize && IsPositionEmpty(pawnA.Row + 1, pawnA.Col - 1, king, pawnB, pawnC, pawnD))
                        {
                            pawnA.Col--;
                            pawnA.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "ADR":
                        if (pawnA.Col < PlayfieldSize && pawnA.Row < PlayfieldSize && IsPositionEmpty(pawnA.Row + 1, pawnA.Col + 1, king, pawnB, pawnC, pawnD))
                        {
                            pawnA.Col++;
                            pawnA.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "BDL":
                        if (pawnB.Col > 0 && pawnB.Row < PlayfieldSize && IsPositionEmpty(pawnB.Row + 1, pawnB.Col - 1, pawnA, king, pawnC, pawnD))
                        {
                            pawnB.Col--;

                            pawnB.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "BDR":
                        if (pawnB.Col < PlayfieldSize && pawnB.Row < PlayfieldSize && IsPositionEmpty(pawnB.Row + 1, pawnB.Col + 1, pawnA, king, pawnC, pawnD))
                        {
                            pawnB.Col++;
                            pawnB.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "CDL":
                        if (pawnC.Col > 0 && pawnC.Row < PlayfieldSize && IsPositionEmpty(pawnC.Row + 1, pawnC.Col + 1, pawnA, pawnB, king, pawnD))
                        {
                            pawnC.Col--;
                            pawnC.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "CDR":
                        if (pawnC.Col < PlayfieldSize && pawnC.Row < PlayfieldSize && IsPositionEmpty(pawnC.Row + 1, pawnC.Col + 1, pawnA, pawnB, king, pawnD))
                        {
                            pawnC.Col++;
                            pawnC.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "DDL":
                        if (pawnD.Col > 0 && pawnD.Row < PlayfieldSize && IsPositionEmpty(pawnD.Row + 1, pawnD.Col - 1, pawnA, pawnB, pawnC, king))
                        {
                            pawnD.Col--;
                            pawnD.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    case "DDR":
                        if (pawnD.Col < PlayfieldSize && pawnD.Row < PlayfieldSize && IsPositionEmpty(pawnD.Row + 1, pawnD.Col + 1, pawnA, pawnB, pawnC, king))
                        {
                            pawnD.Col++;
                            pawnD.Row++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }

                        break;
                    default:
                        Console.Write("Illegal move!");
                        Console.ReadKey();

                        return false;
                }
            }

            return true;
        }

        // Проверява дали позицията на която искаме да се придвижи дадена фигура е свободна! 
        // Ако там вече има фигура - не можеш да се придвижиш върху нея!
        private static bool IsPositionEmpty(int checkedRow, int checkedColumn, Piece piece1, Piece piece2, Piece piece3, Piece piece4)
        {
            if (checkedRow == piece1.Row && checkedColumn == piece1.Col)
            {
                return false;
            }
            else if (checkedRow == piece2.Row && checkedColumn == piece2.Col)
            {
                return false;
            }
            else if (checkedRow == piece3.Row && checkedColumn == piece3.Col)
            {
                return false;
            }
            else if (checkedRow == piece4.Row && checkedColumn == piece4.Col)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Принтира дъската за игра. Взима фигурите като параметри
        private static void PrintGameBoard(Piece pawnA, Piece pawnB, Piece pawnC, Piece pawnD, Piece king)
        {
            const int BoardWidth = 19;
            const int LeftDistanceToUpDownBorder = 3;
            const int PlayfieldSize = 7;

            int columnNumeration = 0;
            for (int i = 0; i < BoardWidth; i++)
            {
                if (i > LeftDistanceToUpDownBorder)
                {
                    if (i % 2 == 0)
                    {
                        // Рисува  горните числа на дъската
                        Console.Write("{0} ", columnNumeration++);
                    }
                }
                else
                {   // ...слага спейс с цел напасване на номерирането на дъската
                    // спрямо съответните полета за игра
                    Console.Write(" ");
                }
            }

            Console.WriteLine();

            // печата горната рамка на полето
            for (int i = 0; i <= BoardWidth; i++)
            {
                if (i < LeftDistanceToUpDownBorder)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write('-');
                }
            }

            Console.WriteLine();

            // печата игралното поле по редове и колони
            for (int row = 0; row <= PlayfieldSize; row++)
            {
                int rowNumeration = row;

                // страничната номерация + лява рамка
                Console.Write("{0} | ", rowNumeration);

                // Тук се печата самото игрално ПОЛЕ!!! С Цар, Пешки и полета "+" или "-"
                for (int col = 0; col <= PlayfieldSize; col++)
                {
                    char symbol = CheckSymbolAtGivenPosition(pawnA, pawnB, pawnC, pawnD, king, row, col);

                    Console.Write(symbol + " ");
                }

                // дясната странична рамка
                Console.WriteLine('|');
            }

            // долната рамка
            for (int i = 0; i <= BoardWidth; i++)
            {
                if (i < LeftDistanceToUpDownBorder)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write('-');
                }
            }

            Console.WriteLine();
        }

        // Проверява на съответната позиция в полето каква фигура да нарисува (или да остави празно поле "+" и "-")
        private static char CheckSymbolAtGivenPosition(Piece pawnA, Piece pawnB, Piece pawnC, Piece pawnD, Piece king, int fieldRow, int fieldCol)
        {
            if (pawnA.Row == fieldRow && pawnA.Col == fieldCol)
            {
                return 'A';
            }
            else if (pawnB.Row == fieldRow && pawnB.Col == fieldCol)
            {
                return 'B';
            }
            else if (pawnC.Row == fieldRow && pawnC.Col == fieldCol)
            {
                return 'C';
            }
            else if (pawnD.Row == fieldRow && pawnD.Col == fieldCol)
            {
                return 'D';
            }
            else if (king.Row == fieldRow && king.Col == fieldCol)
            {
                return 'K';
            }
            else if ((fieldRow + fieldCol) % 2 == 0)
            {
                return '+';
            }
            else
            {
                return '-';
            }
        }

    }
}