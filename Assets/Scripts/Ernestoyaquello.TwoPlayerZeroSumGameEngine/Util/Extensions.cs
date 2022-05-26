using Ernestoyaquello.TwoPlayerZeroSumGameEngine.Models;

namespace Ernestoyaquello.TwoPlayerZeroSumGameEngine.Util
{
    public static class Extensions
    {
        public static Player ToOppositePlayer(this Player player)
        {
            switch(player)
            {
                case Player.First:
                    return Player.Second;
                case Player.Second:
                    return Player.First;
                default:
                    return Player.None;
            }
        }

        public static GameResult? InvertResult(this GameResult? result)
        {
            if (result == null || result == GameResult.StillGame || result == GameResult.Tie)
            {
                return result;
            }
            else
            {
                return result == GameResult.Victory ? GameResult.Defeat : GameResult.Victory;
            }
        }
    }
}
