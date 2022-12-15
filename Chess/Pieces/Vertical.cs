using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    class Vertical
    {
        Position p = new Position();

        public List<string> VerticalMove(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            Up(position, listMoves, board, pieceColor, piece, qtdMove);
            Down(position, listMoves, board, pieceColor, piece, qtdMove);


            return listMoves;
        }

        List<string> Up(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position) - x, p.PositionY(position)] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position)))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) - x));
                        listMoves.Add(move);
                    }
                    else if (pieceColor[p.PositionX(position) - x, p.PositionY(position)] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position) - x, p.PositionY(position)] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position)))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) - x));
                        listMoves.Add(move);
                        break;
                    }
                }
                catch { }
            }
            return listMoves;
        }

        List<string> Down(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position) + x, p.PositionY(position)] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position)))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                        listMoves.Add(move);
                    }
                    else if (pieceColor[p.PositionX(position) + x, p.PositionY(position)] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position) + x, p.PositionY(position)] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position)))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
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
