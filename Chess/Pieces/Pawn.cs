using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        List<string> moves = new List<string>();
        Position position = new Position();

        public Pawn(Colors color, char symbol, string initialPos, Local local) : base(color, symbol, initialPos, local)
        {

        }

        public override List<string> PossibleMoves(Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            moves.Clear();
            if (Color == Colors.White)
            {
                WhiteMoves(board, lastPiece, lastPos, pieceColor);
                return moves;
            }
            else
            {
                BlackMoves(board, lastPiece, lastPos, pieceColor);
                return moves;
            }
        }

        public override bool CheckPossibleMoves(string move, Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            moves = PossibleMoves(board, lastPiece, lastPos, pieceColor);

            foreach (string s in moves)
            {
                if (move == s)
                {
                    return true;
                }
            }
            return false;
        }

        void WhiteMoves(Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            int pos;
            char ch;

            ch = ActualPos[0];
            pos = ActualPos[1] - 48;
            pos += 1;

            string move = Convert.ToString(ch) + pos;

            CanCapture(move, Colors.White, board, pieceColor);
            EnPassant(move, Colors.White, board, lastPiece, lastPos);

            if (board.ChessBoard[position.PositionX(move), position.PositionY(move)] == "   ")
            {
                moves.Add(move);
                if (QtdMoves < 1)
                {
                    pos += 1;
                    move = Convert.ToString(ch) + pos;
                    if (board.ChessBoard[position.PositionX(move), position.PositionY(move)] == "   ")
                    {
                        moves.Add(move);
                    }
                }
            }            
        }
        void BlackMoves(Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            int pos = new int();
            char ch = new char();

            ch = ActualPos[0];
            pos = ActualPos[1] - 48;
            pos -= 1;

            string move = Convert.ToString(ch) + pos;

            CanCapture(move, Colors.Black, board, pieceColor);
            EnPassant(move, Colors.Black, board, lastPiece, lastPos);

            if (board.ChessBoard[position.PositionX(move), position.PositionY(move)] == "   ")
            {
                moves.Add(move);
                if (QtdMoves < 1)
                {
                    pos -= 1;
                    move = Convert.ToString(ch) + pos;
                    if (board.ChessBoard[position.PositionX(move), position.PositionY(move)] == "   ")
                    {
                        moves.Add(move);
                    }
                }
            }            
        }
        void CanCapture(string move, Colors color, Board board, char[,] pieceColor)
        {
            if (color == Colors.White)
            {
                try
                {
                    if (board.ChessBoard[position.PositionX(move), position.PositionY(move) - 1] != "   "
                        && pieceColor[position.PositionX(move), position.PositionY(move) - 1] == 'b')
                    {
                        string move1 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) - 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));

                        moves.Add(move1);
                    }
                }
                catch { }
                try
                {
                    if (board.ChessBoard[position.PositionX(move), position.PositionY(move) + 1] != "   "
                        && pieceColor[position.PositionX(move), position.PositionY(move) + 1] == 'b')
                    {
                        string move1 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) + 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));

                        moves.Add(move1);
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    if (board.ChessBoard[position.PositionX(move), position.PositionY(move) + 1] != "   "
                        && pieceColor[position.PositionX(move), position.PositionY(move) + 1] == 'w')
                    {
                        string move1 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) + 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));

                        moves.Add(move1);
                    }
                }
                catch { }
                try
                {
                    if (board.ChessBoard[position.PositionX(move), position.PositionY(move) - 1] != "   "
                        && pieceColor[position.PositionX(move), position.PositionY(move) - 1] == 'w')
                    {
                        string move1 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) - 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));

                        moves.Add(move1);
                    }
                }
                catch { }
            }
        }
        void EnPassant(string move, Colors color, Board board, char lastPiece, string lastPos)
        {
            if (color == Colors.White)
            {
                if (move[1] == '6')
                {
                    try
                    {
                        if (board.ChessBoard[position.PositionX(move) + 1, position.PositionY(move) - 1] == " P "
                            && lastPiece == 'P')
                        {
                            if (lastPos == Convert.ToString(position.ReturnPositionX(position.PositionY(move) - 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move) - 1)))
                            {
                                string move2 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) - 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));
                                moves.Add(move2);
                            }
                        }
                    }
                    catch { }
                    try
                    {

                        if (board.ChessBoard[position.PositionX(move) + 1, position.PositionY(move) + 1] == " P "
                                && lastPiece == 'P')
                        {
                            if (lastPos == Convert.ToString(position.ReturnPositionX(position.PositionY(move) + 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move) - 1)))
                            {
                                string move2 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) + 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));
                                moves.Add(move2);
                            }
                        }
                    }
                    catch { }
                }
            }
            else
            {
                if (move[1] == '3')
                {
                    try
                    {
                        if (board.ChessBoard[position.PositionX(move) - 1, position.PositionY(move)] == " P "
                            && lastPiece == 'P')
                        {
                            if (lastPos == Convert.ToString(position.ReturnPositionX(position.PositionY(move) - 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move) + 1)))
                            {
                                string move2 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) - 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move) + 1));
                                moves.Add(move2);
                            }
                        }
                    }
                    catch { }
                    try
                    {
                        if (board.ChessBoard[position.PositionX(move) + 1, position.PositionY(move)] == " P "
                            && lastPiece == 'P')
                        {
                            if (lastPos == Convert.ToString(position.ReturnPositionX(position.PositionY(move) + 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move) + 1)))
                            {
                                string move2 = Convert.ToString(position.ReturnPositionX(position.PositionY(move) + 1))
                                + Convert.ToString(position.ReturnPositionY(position.PositionX(move)));
                                moves.Add(move2);
                            }
                        }
                    }
                    catch { }
                }
            }

        }
        public override void LastSquare(Colors color, List<Piece> listPiece, Board board, string newMove)
        {
            char pieceChosen = 'Q';
            bool outLoop = false; ;
            do
            {
                Console.WriteLine("PIECE PROMOTED!!!!!!\nChoose a new piece to replace:\nQ - Queen\nR - Rook\nB - Bishop\nN - Knight");
                try
                {
                    string pChosen = Console.ReadLine();
                    pieceChosen = char.Parse(pChosen.ToUpper());
                }
                catch
                {
                    Console.WriteLine("Invalid choice");
                }
                switch (pieceChosen)
                {
                    case 'Q':
                        board.ChessBoard[position.PositionX(newMove), position.PositionY(newMove)] = " Q ";
                        Queen queen = new Queen(color, 'Q', newMove, Local.Board);
                        listPiece.Add(queen);
                        outLoop = true;
                        break;
                    case 'R':
                        board.ChessBoard[position.PositionX(newMove), position.PositionY(newMove)] = " R ";
                        Rook rook = new Rook(color, 'R', newMove, Local.Board);
                        listPiece.Add(rook);
                        outLoop = true;
                        break;
                    case 'B':
                        board.ChessBoard[position.PositionX(newMove), position.PositionY(newMove)] = " B ";
                        Bishop bishop = new Bishop(color, 'B', newMove, Local.Board);
                        listPiece.Add(bishop);
                        outLoop = true;
                        break;
                    case 'N':
                        board.ChessBoard[position.PositionX(newMove), position.PositionY(newMove)] = " N ";
                        Knight knight = new Knight(color, 'N', newMove, Local.Board);
                        listPiece.Add(knight);
                        outLoop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Piece!!!");
                        break;
                }
            } while (!outLoop);
        }
    }
}