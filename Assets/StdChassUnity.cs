using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StdGame;

namespace StdChassUnity
{
    static class PieceObjectsTo
    {
        public static Chess.Piece Piece(GameObject obj)
        {
            var ins = obj.GetComponent<StdChassPiece>();
            return TypeOfPieceTo.NewInstent(ins.type);
        }
    }
}
