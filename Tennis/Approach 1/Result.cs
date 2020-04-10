using System;
using JetBrains.Annotations;

namespace Tennis.FirstApproach {
    /// <summary> The result of a game, based on <see cref="Player">players'</see> scores. </summary>
    struct Result
    {

        // TODO: Use Result struct

        /// <summary> The string representation of a victory. </summary>
        public const string WinLabel = "Win";

        /// <summary> The string representation of equal number of points when the score isn't high. </summary>
        public const string EqualityLabel = "All";

        /// <summary> Returns a formatted result. </summary>
        /// <param name="format"> Specify the position of score labels ({0},{1}) and the delimiter. </param>
        /// <returns></returns>
        [StringFormatMethod("format")]
        public string Format(string format = "{0}-{1}")
        {
            // TODO: Get result labels here
            return string.Format(format, scores.Item1, scores.Item2);
        }


        /// <summary> The scores of both opponents. </summary>
        (int, int) scores;

        /// <summary> Creates a new game <see cref="Result"/>. </summary>
        /// <param name="score1"> The score of the first <see cref="Player"/>. </param>
        /// <param name="score2"> The score of the <see cref="Player">opponent</see>.</param>
        public Result(int score1, int score2)
        {
            scores = (score1, score2);
        }

        /// <summary> Creates a new game <see cref="Result"/>. </summary>
        /// <param name="player1"> The first <see cref="Player"/>. </param>
        /// <param name="player2"> The second <see cref="Player"/>.</param>
        public Result(Player player1, Player player2) : this(player1.score, player2.score) { }

        /// <summary>Returns the fully qualified type name of this instance.</summary>
        /// <returns>The fully qualified type name.</returns>
        public override string ToString()
        {
            throw new NotImplementedException($"{nameof(ToString)} method isn't fully implemented yet.");
        }
    }
}
