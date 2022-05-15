using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public class MoveMap
    {
        [Flags]
        public enum Status : byte
        {
            None = 0x00,
            MoveAble = 0x01,
            Enemy = 0x02,
            Friendly = 0x04,
            Special = 0x08,
            Check = 0x10,
            Endof = 0x20
        }

        public Board board { get; private set; }

        public Status[,] map;

        public MoveMap(Board board)
        {
            this.board = board;
            board.GetSize(out int w, out int h);
            map = new Status[w, h];
        }
    }
}
