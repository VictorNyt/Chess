using System;
using System.Collections.Generic;
using System.Text;
using Chess.Pieces;

namespace Chess.ChessProgram
{
    public class Board
    {
        public string[,] ChessBoard { get; set; }
        public char[,] PieceColor { get; set; }

        public Board()
        {

        }

        public Board(string[,] chessBoard, char[,] pieceColor)
        {
            ChessBoard = chessBoard;
            PieceColor = pieceColor;
        }

        int x, y;

        public void StartBoard()
        {
            CleanBoard();
        }
        void CleanBoard()
        {
            for (int x = 0; x < ChessBoard.GetLength(0); x++)
            {
                for (int y = 0; y < ChessBoard.GetLength(1); y++)
                {
                    ChessBoard[x, y] = "   ";
                }
            }
        }
        public void DrawBoard(List<string> moves, bool isMove)
        {
            Console.Clear();
            int count = 8;
            for (x = 0; x < ChessBoard.GetLength(0); x++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(count);
                for (y = 0; y < ChessBoard.GetLength(1); y++)
                {
                    bool preMove = false;
                    foreach(string s in moves)
                    {
                        Position pos = new Position();
                        if(x == pos.PositionX(s) && y == pos.PositionY(s))
                        {
                            preMove = true;
                            break;
                        }
                        else
                        {
                            preMove = false;
                        }
                    }
                    if (PieceColor[x, y] == 'b')
                    {
                        BackgroundColor(preMove, isMove);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(ChessBoard[x, y]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (PieceColor[x, y] == 'w')
                    {
                        BackgroundColor(preMove, isMove);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(ChessBoard[x, y]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        BackgroundColor(preMove, isMove);
                        Console.Write(ChessBoard[x, y]);
                    }
                }
                Console.WriteLine();
                count--;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("  a  b  c  d  e  f  g  h");
        }
        void BackgroundColor(bool preMove, bool isMove)
        {
            if (preMove && isMove)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (x % 2 == 0 && y % 2 == 1 || x % 2 == 1 && y % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
        }
    }
}