using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessProgram;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        List<string> moves = new List<string>();

        public Knight(Colors color, char symbol, string initialPos, Local local) : base(color, symbol, initialPos, local)
        {

        }

        public override List<string> PossibleMoves(Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            LMove lMove = new LMove();
            moves = lMove.LMoving(ActualPos, moves, board, pieceColor, this);
            return moves;
        }

        public override bool CheckPossibleMoves(string move, Board board, char lastPiece, string lastPos, char[,] pieceColor)
        {
            PossibleMoves(board, lastPiece, lastPos, pieceColor);

            moves = PossibleMoves(board, lastPiece, lastPos, pieceColor);

            foreach (string s in moves)
            {
                if (move == s)
                {
                    return true;
                }
            }
            return false;
        }
        public override void LastSquare(Colors color, List<Piece> listPiece, Board board, string newMove){ }
    }
}
