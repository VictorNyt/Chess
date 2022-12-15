using System;
using System.Collections.Generic;
using System.Text;
using Chess.Pieces;

namespace Chess.ChessProgram
{
    public class Movement
    {
        Position position = new Position();
        public void Moving(char[,] pieceColor, Board board, string newMove, char color, string piece, 
            string move, List<Piece> pieces)
        {
            Position pos = new Position();
            if (board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] == " P " 
                && board.ChessBoard[pos.PositionX(move), pos.PositionY(newMove)] == " P " 
                && board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove)] == "   ")
            {

                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove)] = color;
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove)] = piece;
                pieceColor[pos.PositionX(move), pos.PositionY(move)] = ' ';
                board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] = "   ";
                pieceColor[pos.PositionX(move), pos.PositionY(newMove)] = ' ';
                board.ChessBoard[pos.PositionX(move), pos.PositionY(newMove)] = "   ";
            }
            else if(board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] == " K "
                && board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove) + 1] == " R ")
            {
                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove)] = color;
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove)] = piece;
                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove) - 1] = color;
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove) - 1] = " R ";
                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove) + 1] = ' ';
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove) + 1] = "   ";
                pieceColor[pos.PositionX(move), pos.PositionY(move)] = ' ';
                board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] = "   ";
                foreach(Piece p in pieces)
                {
                    if(p.Symbol == 'R')
                    {
                        if (p.ActualPos == Convert.ToString(position.ReturnPositionX(position.PositionY(newMove) + 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(newMove))))
                        {
                            p.ActualPos = Convert.ToString(position.ReturnPositionX(position.PositionY(newMove) - 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(newMove)));
                        }
                    }
                }
            }
            else if (board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] == " K "
                && board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove) - 1] == " R ")
            {
                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove)] = color;
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove)] = piece;
                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove) + 1] = color;
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove) + 1] = " R ";
                pieceColor[pos.PositionX(newMove), pos.PositionY(newMove) - 1] = ' ';
                board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove) - 1] = "   ";
                pieceColor[pos.PositionX(move), pos.PositionY(move)] = ' ';
                board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] = "   ";
                foreach (Piece p in pieces)
                {
                    if (p.Symbol == 'R')
                    {
                        if (p.ActualPos == Convert.ToString(position.ReturnPositionX(position.PositionY(newMove) - 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(newMove))))
                        {
                            p.ActualPos = Convert.ToString(position.ReturnPositionX(position.PositionY(newMove) + 1))
                            + Convert.ToString(position.ReturnPositionY(position.PositionX(newMove)));
                        }
                    }
                }
            }
            else
            {
                NormalMove(pieceColor, board, newMove, color, piece, move);
            }
        }

        void NormalMove(char[,] pieceColor, Board board, string newMove, char color, string piece, string move)
        {
            Position pos = new Position();
            pieceColor[pos.PositionX(newMove), pos.PositionY(newMove)] = color;
            board.ChessBoard[pos.PositionX(newMove), pos.PositionY(newMove)] = piece;
            pieceColor[pos.PositionX(move), pos.PositionY(move)] = ' ';
            board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] = "   ";
        }
    }
}
