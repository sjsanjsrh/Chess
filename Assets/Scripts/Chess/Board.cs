using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public class Board
    {
        public System.Enum currentPlayer;
        public Game game { get; protected set; }

        private Piece[,] mMap;

        public Board(Game game, int w, int h)
        {
            this.game = game;
            mMap = new Piece[w, h];
        }

        public Board Clone()
        {
            return (Board)MemberwiseClone();
        }

        public void GetSize(out int w, out int h)
        {
            w = mMap.GetLength(0);
            h = mMap.GetLength(1);
        }

        public Piece PutPiece(Piece piece, int x, int y)
        {
            Piece priv = mMap[x, y];
            mMap[x, y] = piece;
            return priv;
        }

        public Piece RemovePiece(int x, int y)
        {
            Piece priv = mMap[x, y];
            mMap[x, y] = null;
            return priv;
        }

        public Piece MovePiece(int src_x, int src_y, int dis_x, int dis_y)
        {
            mMap[dis_x, dis_y] = mMap[src_x, src_y];
            return RemovePiece(src_x, src_y);
        }

        public Piece GetPiece(int x, int y)
        {
            return mMap[x, y];
        }

        public Piece[,] GetPiece()
        {
            return mMap;
        }
    }
}