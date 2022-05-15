using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Piece
    {
        public string name { get; protected set; }
        public MoveMap moveMap { get; private set; }
        public Board board { get; private set; }
        public System.Enum owner;

        private int x, y;

        public Piece Place(Board board, int x, int y)
        {
            this.board = board;
            board.PutPiece(this, x, y);
            SetPosition(x, y);
            moveMap = new MoveMap(board);
            return this;
        }

        public void GetPosition(out int x, out int y)
        {
            x = this.x;
            y = this.y;
        }

        private void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void ComputingMoveMap();
    }
}
