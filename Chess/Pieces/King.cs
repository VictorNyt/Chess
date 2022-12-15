using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    public class King : Piece
    {
        List<string> moves = new List<string>();

        public King(Colors color, char symbol, string initialPos, Local local) : base(color, symbol, initialPos, local)
        {

        }

        public override List<string> PossibleMoves(Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            Vertical vertical = new Vertical();
            moves = vertical.VerticalMove(ActualPos, moves, board, pieceColor, this, 2);
            Horizontal horizontal = new Horizontal();
            moves = horizontal.HorizontalMove(ActualPos, moves, board, pieceColor, this, 2);
            Diagonal diagonal = new Diagonal();
            moves = diagonal.DiagonalMove(ActualPos, moves, board, pieceColor, this, 2);
            moves = Castle(ActualPos, moves, board, pieceColor, this, 2);
            return moves;
        }

        List<string> Castle(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            Position p = new Position();
            int roque = 0;


            if (QtdMoves == 0)
            {
                try
                {
                    for (int x = 1; x < 5; x++)
                    {
                        if (board.ChessBoard[p.PositionX(position), p.PositionY(position) - x] == "   ")
                        {
                            roque++;
                        }
                        else
                        {
                            if (board.ChessBoard[p.PositionX(position), p.PositionY(position) - x] == " R " && roque > 1)
                            {
                                listMoves.Add(Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x + 1))
                                    + Convert.ToString(p.ReturnPositionY(p.PositionX(position))));
                            }
                            break;
                        }
                    }
                }
                catch { }
                try
                {
                    for (int x = 1; x < 5; x++)
                    {
                        if (board.ChessBoard[p.PositionX(position), p.PositionY(position) + x] == "   ")
                        {
                            roque++;
                        }
                        else
                        {
                            if (board.ChessBoard[p.PositionX(position), p.PositionY(position) + x] == " R " && roque > 1)
                            {
                                listMoves.Add(Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x - 1))
                                    + Convert.ToString(p.ReturnPositionY(p.PositionX(position))));
                            }
                            break;
                        }
                    }
                }
                catch { }
            }

            return listMoves;
        }


        public override bool CheckPossibleMoves(string move, Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            PossibleMoves(board, lastPiece, lastPos, pieceColor);

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

        public override void LastSquare(Colors color, List<Piece> listPiece, Board board, string newMove) { }
    }
}
