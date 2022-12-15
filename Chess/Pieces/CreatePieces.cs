using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Pieces
{
    class CreatePieces
    {
        public void CreateBoardPieces(List<Piece> pieces)
        {
            char[] c = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            #region White Pieces
            King WhiteKing = new King(Colors.White, 'K', "e1", Local.NotSet);
            Queen WhiteQueen = new Queen(Colors.White, 'Q', "d1", Local.NotSet);
            Rook WhiteRook1 = new Rook(Colors.White, 'R', "a1", Local.NotSet);
            Rook WhiteRook2 = new Rook(Colors.White, 'R', "h1", Local.NotSet);
            Knight WhiteKnight1 = new Knight(Colors.White, 'N', "b1", Local.NotSet);
            Knight WhiteKnight2 = new Knight(Colors.White, 'N', "g1", Local.NotSet);
            Bishop WhiteBishop1 = new Bishop(Colors.White, 'B', "c1", Local.NotSet);
            Bishop WhiteBishop2 = new Bishop(Colors.White, 'B', "f1", Local.NotSet);
            for (int x = 0; x < 8; x++)
            {
                Pawn WhitePawn = new Pawn(Colors.White, 'P', c[x]+"2", Local.NotSet);
                pieces.Add(WhitePawn);
            }
            #endregion
            #region Black Pieces
            King BlackKing = new King(Colors.Black, 'K', "e8", Local.NotSet);
            Queen BlackQueen = new Queen(Colors.Black, 'Q', "d8", Local.NotSet);
            Rook BlackRook1 = new Rook(Colors.Black, 'R', "a8", Local.NotSet);
            Rook BlackRook2 = new Rook(Colors.Black, 'R', "h8", Local.NotSet);
            Knight BlackKnight1 = new Knight(Colors.Black, 'N', "b8", Local.NotSet);
            Knight BlackKnight2 = new Knight(Colors.Black, 'N', "g8", Local.NotSet);
            Bishop BlackBishop1 = new Bishop(Colors.Black, 'B', "c8", Local.NotSet);
            Bishop BlackBishop2 = new Bishop(Colors.Black, 'B', "f8", Local.NotSet);
            for (int x = 0; x < 8; x++)
            {
                Pawn BlackPawn = new Pawn(Colors.Black, 'P', c[x] + "7", Local.NotSet);
                pieces.Add(BlackPawn);
            }
            #endregion
            #region Add to List
            pieces.Add(WhiteKing);
            pieces.Add(WhiteQueen);
            pieces.Add(WhiteRook1);
            pieces.Add(WhiteRook2);
            pieces.Add(WhiteKnight1);
            pieces.Add(WhiteKnight2);
            pieces.Add(WhiteBishop1);
            pieces.Add(WhiteBishop2);
            pieces.Add(BlackKing);
            pieces.Add(BlackQueen);
            pieces.Add(BlackRook1);
            pieces.Add(BlackRook2);
            pieces.Add(BlackKnight1);
            pieces.Add(BlackKnight2);
            pieces.Add(BlackBishop1);
            pieces.Add(BlackBishop2);
            #endregion
        }
    }
}