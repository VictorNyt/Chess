using System;
using System.Collections.Generic;
using System.Text;
using Chess.Pieces;

namespace Chess.ChessProgram
{
    class ChessGame
    {
        public void StartGame()
        {
            char[,] pieceColor = new char[8, 8];
            DefaultColors(pieceColor);
            Position pos = new Position();
            string[,] chessBoard = new string[8, 8];
            Board board = new Board(chessBoard, pieceColor);
            List<Piece> pieces = new List<Piece>();

            board.StartBoard();
            pos.SetPieces(pieces, board.ChessBoard);

            bool gameOn = true;
            Turns turn = new Turns();
            do
            {
                gameOn = turn.Turn(pieceColor, board, pieces);
            } while (gameOn);
        }

        void DefaultColors(char[,] loopChar)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    loopChar[x, y] = 'b';
                }
            }
            for (int x = 6; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    loopChar[x, y] = 'w';
                }
            }
        }
    }
}
