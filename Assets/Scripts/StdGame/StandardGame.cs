using System.Collections;
using System.Collections.Generic;
using Chess;

namespace StdGame
{
    public enum Faction
    {
        Black,
        White
    }

    public enum TypeOfPiece
    {
        Pawn
    }
    static class TypeOfPieceTo
    {
        static public Piece NewInstent(TypeOfPiece value)
        {
            switch (value)
            {
                case (TypeOfPiece.Pawn):
                    return new Pawn();
                default:
                    return null;
            }
        }
    }

    public class StandardGame : Game
    {
        public override int BOARD_W { get; protected set; } = 8;
        public override int BOARD_H { get; protected set; } = 8;

        public override void Init()
        {
            NewBoard();
            GetCurrentBoard().currentPlayer = Faction.Black;

            PlacePieceAtCurrent<Pawn>(Faction.White, 0, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 1, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 2, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 3, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 4, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 5, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 6, 1);
            PlacePieceAtCurrent<Pawn>(Faction.White, 7, 1);

            PlacePieceAtCurrent<Pawn>(Faction.Black, 0, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 1, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 2, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 3, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 4, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 5, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 6, 6);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 7, 6);

            // For testing
            PlacePieceAtCurrent<Pawn>(Faction.Black, 6, 2);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 7, 3);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 6, 4);
            PlacePieceAtCurrent<Pawn>(Faction.Black, 7, 5);

            ComputingMoveMap();
        }
        
        public void ComputingMoveMap()
        {
            foreach(var piece in GetCurrentBoard().GetPiece())
            {
                piece?.ComputingMoveMap();
            }
        }

        public override void BeforeTurn()
        {
            throw new System.NotImplementedException();
        }

        public override void NextTurn()
        {
            throw new System.NotImplementedException();
        }

    }
}
