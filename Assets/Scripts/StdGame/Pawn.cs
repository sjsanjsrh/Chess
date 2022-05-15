using System.Collections;
using System.Collections.Generic;
using Chess;

namespace StdGame
{
    public class Pawn : Piece
    {
        private bool notMoved = true;
        private StandardMove.CheckHandler checkMove;
        private StandardMove.CheckHandler checkKill;

        public Pawn() : base()
        {
            checkMove = delegate (int x, int y, int i)
            {
                var piece = board.GetPiece(x, y);
                if (piece == null)
                {
                    moveMap.map[x, y] |= MoveMap.Status.MoveAble;
                }
                else
                {
                    if((Faction)owner == (Faction)board.GetPiece(x, y).owner)
                        moveMap.map[x, y] |= MoveMap.Status.Friendly;
                    else
                        moveMap.map[x, y] |= MoveMap.Status.Enemy;
                    return false;
                }
                return true;
            };

            checkKill = delegate (int x, int y, int i)
            {
                var piece = board.GetPiece(x, y);
                if (piece != null)
                {
                    if ((Faction)owner != (Faction)board.GetPiece(x, y).owner)
                    {
                        moveMap.map[x, y] |= MoveMap.Status.Enemy;
                        moveMap.map[x, y] |= MoveMap.Status.MoveAble;
                    }
                    return false;
                }
                return true;
            };
        }

        public override void ComputingMoveMap()
        {
            int len = notMoved ? 2 : 1;

            if((Faction)owner == Faction.Black)
            {
                StandardMove.Straight_dd(this, len, checkMove);
                StandardMove.Dot(this, 1, -1, checkKill);
                StandardMove.Dot(this, -1, -1, checkKill);
            }
            else
            {
                StandardMove.Straight_uu(this, len, checkMove);
                StandardMove.Dot(this, 1, 1, checkKill);
                StandardMove.Dot(this, -1, 1, checkKill);
            }

        }
    }
}
