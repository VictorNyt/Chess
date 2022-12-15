using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    class Horizontal
    {
        Position p = new Position();

        public List<string> HorizontalMove(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            Left(position, listMoves, board, pieceColor, piece, qtdMove);
            Right(position, listMoves, board, pieceColor, piece, qtdMove);


            return listMoves;
        }

        List<string> Left(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position), p.PositionY(position) - x] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position)));
                        listMoves.Add(move);
                    }
                    else if (pieceColor[p.PositionX(position), p.PositionY(position) - x] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position), p.PositionY(position) - x] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position)));
                        listMoves.Add(move);
                        break;
                    }
                }
                catch { }
            }
            return listMoves;
        }

        List<string> Right(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position), p.PositionY(position) + x] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position)));
                        listMoves.Add(move);
                    }
                    else if (pieceColor[p.PositionX(position), p.PositionY(position) + x] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position), p.PositionY(position) + x] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position)));
                        listMoves.Add(move);
                        break;
                    }
                }
                catch { }
            }
            return listMoves;
        }
    }
}
