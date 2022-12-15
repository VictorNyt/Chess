using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ChessProgram
{
    class MainMenu
    {
        bool loop = true;
        string dec = "";
        public void Start()
        { 
            do
            {
                Console.Clear();
                Console.WriteLine("Chess\n1 - Player\n2 - Players\n3 - Exit");
                string players = Console.ReadLine();
                switch (players)
                {
                    case "1":
                        Console.WriteLine("Not working. GET OUT");
                        break;
                    case "2":
                        ChessGame chess = new ChessGame();
                        chess.StartGame();

                        break;
                    default:
                        Console.WriteLine("BRUH, take a correct answer, You fool\nWant to get out?");
                        Exit();
                        break;
                }
            } while (loop);
        }
        
        void Exit()
        {
            Console.WriteLine("Want get out?\nY - Yes\nN - No");
            dec = Console.ReadLine();
            if (dec == "y" | dec == "Y" | dec == "yes" | dec == "Yes" | dec == "s" | dec == "S")
            {
                Environment.Exit(0);
            }
        }
    }
}
