using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    class LMove
    {
        Position p = new Position();
        public List<string> LMoving(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece)
        {
            listMoves = Horizontal(position, listMoves, board, pieceColor, piece);
            listMoves = Vertical(position, listMoves, board, pieceColor, piece);
            return listMoves;
        }

        List<string> Horizontal(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece)
        {

            for (int x = -1; x < 2; x += 2)
            {
                for (int y = -2; y < 3; y += 4)
                {
                    try
                    {
                        if (board.ChessBoard[p.PositionX(position) + x, p.PositionY(position) + y] == "   ")
                        {
                            string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + y))
                                + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                            listMoves.Add(move);
                        }
                        if (board.PieceColor[p.PositionX(position) + x, p.PositionY(position) + y] == 'b'
                            && pieceColor[p.PositionX(position), p.PositionY(position)] == 'w')
                        {
                            string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + y))
                                + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                            listMoves.Add(move);
                        }
                        if (board.PieceColor[p.PositionX(position) + x, p.PositionY(position) + y] == 'w'
                            && pieceColor[p.PositionX(position), p.PositionY(position)] == 'b')
                        {
                            string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + y))
                                + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + x));
                            listMoves.Add(move);
                        }
                    }
                    catch { }
                }
            }

            return listMoves;
        }

        List<string> Vertical(string position, List<string> listMoves, Board board, char[,] pieceColor, Piece piece)
        {

            for (int x = -1; x < 2; x += 2)
            {
                for (int y = -2; y < 3; y += 4)
                {
                    try
                    {
                        if (board.ChessBoard[p.PositionX(position) + y, p.PositionY(position) + x] == "   ")
                        {
                            string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                                    + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + y));
                            listMoves.Add(move);
                        }
                        if (board.PieceColor[p.PositionX(position) + y, p.PositionY(position) + x] == 'b'
                            && pieceColor[p.PositionX(position), p.PositionY(position)] == 'w')
                        {
                            string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                                    + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + y));
                            listMoves.Add(move);
                        }
                        if (board.PieceColor[p.PositionX(position) + y, p.PositionY(position) + x] == 'w'
                            && pieceColor[p.PositionX(position), p.PositionY(position)] == 'b')
                        {
                            string move = Convert.ToString(p.ReturnPositionX(p.PositionY(position) + x))
                                    + Convert.ToString(p.ReturnPositionY(p.PositionX(position) + y));
                            listMoves.Add(move);
                        }
                    }
                    catch { }
                }
            }

            return listMoves;
        }
    }
}