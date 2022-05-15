using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Game
    {
        public abstract int BOARD_W { get; protected set; }
        public abstract int BOARD_H { get; protected set; }

        private LinkedList<Board> mainBranch = new LinkedList<Board>();

        public abstract void Init();

        public abstract void BeforeTurn();
        public abstract void NextTurn();

        public Board GetCurrentBoard()
        {
            return mainBranch.Last.Value;
        }
        public Piece GetCurrentPice(int x, int y)
        {
            return GetCurrentBoard().GetPiece(x, y);
        }
        public Board NewBoard()
        {
            Board newBoard = new Board(this, BOARD_W, BOARD_H);
            mainBranch.AddLast(newBoard);
            return newBoard;
        }
        public void PlacePieceAtCurrent<T>(Enum owner, int x, int y) where T : Piece, new()
        {
            var newPiece = new T();
            Board board = GetCurrentBoard();
            board.PutPiece(newPiece.Place(board, x, y), x, y);
            newPiece.owner = owner;
        }
    }
}
