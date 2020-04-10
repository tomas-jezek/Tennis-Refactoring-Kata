using System;
using System.Linq;

namespace Tennis.FirstApproach
{
    /// <summary> Additional helper methods for simplifying tennis score displaying. </summary>
    static class TennisExtensions
    {
        /// <summary> Checks if both elements of a tuple pair conform to a condition. </summary>
        /// <typeparam name="T"> The type of the tuple. </typeparam>
        /// <param name="pair"> The pair. </param>
        /// <param name="condition"> The condition to be satisfied by both elements of the pair. </param>
        /// <returns></returns>
        public static bool Both<T>(this (T first, T second) pair, Predicate<T> condition)
        {
            (T first, T second) = pair;
            return condition.Invoke(first) && condition.Invoke(second);
        }

        /// <summary> Checks if at least one element of a tuple pair conforms to a condition. </summary>
        /// <typeparam name="T"> The type of the tuple. </typeparam>
        /// <param name="pair"> The pair. </param>
        /// <param name="condition"> The condition to be satisfied by at least one element of the pair. </param>
        /// <returns></returns>
        public static bool Either<T>(this (T first, T second) pair, Predicate<T> condition)
        {
            (T first, T second) = pair;
            return condition.Invoke(first) || condition.Invoke(second);
        }
    }

    /// <summary> Additional helper methods for simplifying tennis score displaying. </summary>
    static class TennisUtils
    {
        /// <summary> Returns the winning player with the highest score. </summary>
        public static Player GetWinningPlayer(params Player[] players)
        {
            return players.OrderByDescending(p => p.score).FirstOrDefault();
        }

        /// <summary> Maps a score for a single player, between 0 and 3. </summary>
        /// <remarks> It doesn't work with other scores because they're related to the other player's score. </remarks>
        /// <param name="score"> The score the <see cref="Player"/> has gathered. </param>
        public static ScoreLabel MapIndividualScore(int score)
        {
            switch (score)
            {
                case 0:
                    return ScoreLabel.Love;
                case 1:
                    return ScoreLabel.Fifteen;
                case 2:
                    return ScoreLabel.Thirty;
                case 3:
                    return ScoreLabel.Forty;
                default:
                    throw new InvalidOperationException("Unsupported score for mapping.");
            }
        }
    }
}
