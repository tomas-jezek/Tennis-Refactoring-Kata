using System;

namespace Tennis.FirstApproach {
    /// <summary> The result of a game, based on <see cref="Player">players'</see> scores. </summary>
    struct Result
    {
        /// <summary> All the possible score denominators. </summary>
        enum Scores
        {
            /// <summary> Zero points. </summary>
            Love,
            /// <summary> One point. </summary>
            Fifteen,
            /// <summary> Two points. </summary>
            Thirty,
            /// <summary> Three points. </summary>
            Forty,
            /// <summary> Equal number of points over three. </summary>
            Deuce,
            /// <summary> Unequal number of points over three. </summary>
            Advantage
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
