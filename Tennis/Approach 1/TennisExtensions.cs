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
    }
    /// <summary> Additional helper methods for simplifying tennis score displaying. </summary>
    static class TennisUtils
    {
        /// <summary> Returns the winning player with the highest score. </summary>
        public static Player GetWinningPlayer(params Player[] players)
        {
            return players.OrderByDescending(p => p.score).FirstOrDefault();
        }
    }
}
