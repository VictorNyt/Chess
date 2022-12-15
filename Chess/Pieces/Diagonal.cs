 using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    class Diagonal
    {
        Position p = new Position();

        public List<string> DiagonalMove(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            listMoves = DiagonalUpRight(position, listMoves, board, pieceColor, piece, qtdMove);
            listMoves = DiagonalUpLeft(position, listMoves, board, pieceColor, piece, qtdMove);
            listMoves = DiagonalDownRight(position, listMoves, board, pieceColor, piece, qtdMove);
            listMoves = DiagonalDownLeft(position, listMoves, board, pieceColor, piece, qtdMove);

            return listMoves;
        }

        List<string> DiagonalUpRight(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position) - x, p.PositionY(position) + x] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) - x));
                        listMoves.Add(move);
                    }
                    else if(pieceColor[p.PositionX(position) - x, p.PositionY(position) + x] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position) - x, p.PositionY(position) + x] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) - x));
                        listMoves.Add(move);
                        break;
                    }
                }
                catch { }
            }
            return listMoves;
        }
        List<string> DiagonalUpLeft(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position) - x, p.PositionY(position) - x] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) - x));
                        listMoves.Add(move);
                    }
                    else if(pieceColor[p.PositionX(position) - x, p.PositionY(position) - x] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position) - x, p.PositionY(position) - x] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) - x));
                        listMoves.Add(move);
                        break;
                    }
                }
                catch { }
            }
            return listMoves;
        }
        List<string> DiagonalDownRight(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position) + x, p.PositionY(position) + x] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                        listMoves.Add(move);
                    }
                    else if(pieceColor[p.PositionX(position) + x, p.PositionY(position) + x] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position) + x, p.PositionY(position) + x] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                        listMoves.Add(move);
                        break;
                    }
                }
                catch { }
            }
            return listMoves;
        }
        List<string> DiagonalDownLeft(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece, int qtdMove)
        {
            for (int x = 1; x < qtdMove; x++)
            {
                try
                {
                    if (board.ChessBoard[p.PositionX(position) + x, p.PositionY(position) - x] == "   ")
                    {

                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x))
                            + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                        listMoves.Add(move);
                    }
                    else if(pieceColor[p.PositionX(position) + x, p.PositionY(position) - x] == 'b' && piece.Color == Colors.Black
                        || pieceColor[p.PositionX(position) + x, p.PositionY(position) - x] == 'w' && piece.Color == Colors.White)
                    {
                        break;
                    }
                    else
                    {
                        string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) - x))
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
