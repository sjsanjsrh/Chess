using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    // ru uu lu
    // rr    ll
    // rd dd ld
    public static class StandardMove
    {
        public delegate bool CheckHandler(int x, int y, int i);

        public static void Dot(Piece piece, int x ,int y, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int _x, out int _y);

            int sx = x + _x;
            int sy = y + _y;

            if (sx >= 0 && sy >= 0 && sx < w && sy < h)
            {
                handler(sx, sy, 0);
            }
        }

        public static void Straight_dd(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            for (int i = 1; i < y && i <= len; i++)
            {
                if (!handler(x, y - i, i)) break;
            }
        }
        public static void Straight_ll(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            for (int i = 1; i < x && i <= len; i++)
            {
                if (!handler(x - i, y, i)) break;
            }
        }
        public static void Straight_uu(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            for (int i = 1; i < h-y-1 && i <= len; i++)
            {
                if (!handler(x, y + i, i)) break;
            }
        }
        public static void Straight_rr(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            for (int i = 1; i < w-x-1 && i <= len; i++)
            {
                if (!handler(x + i, y, i)) break;
            }
        }
        public static void Straight_ld(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            throw new System.NotImplementedException();
        }
        public static void Straight_ru(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            throw new System.NotImplementedException();
        }
        public static void Straight_lu(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            throw new System.NotImplementedException();
        }
        public static void Straight_rd(Piece piece, int len, CheckHandler handler)
        {
            piece.board.GetSize(out int w, out int h);
            piece.GetPosition(out int x, out int y);

            throw new System.NotImplementedException();
        }
    }
}