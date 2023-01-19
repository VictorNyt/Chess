using System;
using System.Collections.Generic;
using System.Text;
using Chess.Pieces;

namespace Chess.ChessProgram
{
    class Turns
    {
        int CountTurns { get; set; }
        Colors color;
        string move;
        Position pos = new Position();
        string pieceSymbol, lastPos = "q";
        List<string> moves = new List<string> { "  " };
        char lastPiece = 'p';

        public Turns()
        {
            CountTurns = 1;
        }

        public bool Turn(char[,] pieceColor, Board board, List<Piece> listPiece)
        {
            do
            {
                if (CountTurns % 2 == 0)
                {
                    color = Colors.Black;
                }
                else
                {
                    color = Colors.White;
                }
                bool canMove, fault;
                //Loop para tratar um erro de escrita
                do
                {
                    moves.Clear();
                    moves.Add("   ");
                    board.DrawBoard(moves, false);

                    Console.WriteLine($"Turn {CountTurns}: {color}\n");
                    Console.WriteLine("Type: 'Exit' to exit the game");
                    Console.Write($"{color} move: ");

                    move = Console.ReadLine();
                    if(move == "exit" || move == "Exit")
                    {
                        MainMenu menu = new MainMenu();
                        menu.Start();
                    }
                    else
                    {
                        try
                        {
                            pieceSymbol = board.ChessBoard[pos.PositionX(move), pos.PositionY(move)];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid value");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                    }

                } while (true);

                moves.Clear();
                if (board.ChessBoard[pos.PositionX(move), pos.PositionY(move)] == "   ")
                {
                    moves.Clear();
                    moves.Add("   ");
                    board.DrawBoard(moves, false);
                    Console.WriteLine("No piece chosen. Invalid");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    foreach (Piece p in listPiece)
                    {
                        if (p.Symbol == pieceSymbol[1] && p.ActualPos == move && p.Color == color)
                        {
                            char color;
                            moves = p.PossibleMoves(board, lastPiece, lastPos, pieceColor);
                            board.DrawBoard(moves, true);
                            Console.WriteLine("Choose where to move the piece: ");
                            string newMove = Console.ReadLine();
                            canMove = p.CheckPossibleMoves(newMove, board, lastPiece, lastPos, pieceColor);
                            fault = true;
                            if (p.Color == Colors.White)
                            {
                                color = 'w';
                            }
                            else
                            {
                                color = 'b';
                            }
                            if (canMove && fault)
                            {
                                Movement movement = new Movement();
                                movement.Moving(pieceColor, board, newMove, color,
                                    board.ChessBoard[pos.PositionX(move), pos.PositionY(move)], move, listPiece);
                                lastPos = p.ActualPos;
                                p.ActualPos = newMove;
                                p.QtdMoves += 1;
                                lastPiece = p.Symbol;
                                CountTurns++;
                                if(newMove[1] == '8' && p.Symbol == 'P' || newMove[1] == '1' && p.Symbol == 'P')
                                {
                                    p.LastSquare(p.Color, listPiece, board, newMove);
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid movement");
                                Console.WriteLine("Press any key...");
                                Console.ReadKey();
                            }
                        }
                    }
                }
            } while (true);






            if (true)
            {
                return true;
            }
        }
    }
}