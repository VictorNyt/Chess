using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public Colors Color { get; set; }
        public char Symbol { get; set; }
        public string InitialPos { get; set; }
        public string ActualPos { get; set; }
        public int QtdMoves { get; set; }
        public Local Localize { get; set; }

        public Piece(Colors color, char symbol, string initialPos, Local local)
        {
            Color = color;
            Symbol = symbol;
            InitialPos = initialPos;
            ActualPos = initialPos;
            Localize = local;
            QtdMoves = 0;
        }

        public abstract List<string> PossibleMoves(Board board, char lastPiece, string lastPos, char[,] pieceColor);
        public abstract bool CheckPossibleMoves(string move, Board board, char lastPiece, string lastPos, char[,] pieceColor);
        public abstract void LastSquare(Colors color, List<Piece> listPiece, Board board, string newMove);
    }
}
