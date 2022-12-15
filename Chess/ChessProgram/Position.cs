using System;
using System.Collections.Generic;
using System.Text;
using Chess.Pieces;

namespace Chess.ChessProgram
{
    class Position
    {
        CreatePieces cp = new CreatePieces();

        public void SetPieces(List<Piece> pieces, string[,] board)
        {
            cp.CreateBoardPieces(pieces);
            foreach (var p in pieces)
            {
                board[PositionX(p.InitialPos), PositionY(p.InitialPos)] = " " + p.Symbol + " ";
            }
        }

        public bool ValidatePosition(string pos, int x, int y)
        {
            if(PositionX(pos) == x && PositionY(pos) == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Find position on board
        public int PositionX(string pos)
        {
            char[] testeArray = { '8','7','6','5','4','3','2','1' };
            for (int x = 0; x < testeArray.Length; x++)
            {
                if (pos[1] == testeArray[x])
                {
                    return x;
                }
            }
            return 10;
        }
        public int PositionY(string pos)
        {
            char[] testeArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            for (int x = 0; x < testeArray.Length; x++)
            {
                if (pos[0] == testeArray[x])
                {
                    return x;
                }
            }
            return 10;
        }
        public int ReturnPositionY(int y)
        {
            int[] testeArray = { 8, 7, 6, 5, 4, 3, 2, 1 };
            return testeArray[y];
        }
        public char ReturnPositionX(int x)
        {
            char[] testeArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            return testeArray[x];
            
        }
        #endregion
    }
}
