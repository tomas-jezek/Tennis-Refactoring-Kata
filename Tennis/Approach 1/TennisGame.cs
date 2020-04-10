using System;

namespace Tennis.FirstApproach
{
    /// <summary> A single game of tennis. </summary>
    class TennisGame : ITennisGame
    {
        Player player1;
        Player player2;

        /// <summary> The string representation of a victory. </summary>
        public const string WinLabel = "Win";
        /// <summary> The string representation of equal number of points when the score isn't high. </summary>
        public const string EqualityLabel = "All";
        /// <summary> The delimiter put between the scores. </summary>
        public const string Delimiter = "-";

        /// <summary> Gets the player with the higher score. </summary>
        public Player WinningPlayer => TennisUtils.GetWinningPlayer(player1, player2);
        /// <summary> Both of the players' scores. </summary>
        public (int, int) Scores => (player1.score, player2.score);

        /// <summary> Creates an instance of a new game. </summary>
        /// <param name="player1Name"> The name of the first <see cref="Player"/>. </param>
        /// <param name="player2Name"> The name of the second <see cref="Player"/>. </param>
        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        /// <summary> Adds a point for the given player. </summary>
        /// <remarks> A <see langword="string"/> name of the player. </remarks>
        /// <param name="playerName"> The name of the player to add a point to. </param>
        public void WonPoint(string playerName)
        {
            if (playerName == player1.name) player1.AddPoint();
            else player2.AddPoint();
        }

        /// <summary> Constructs a string summarising the score. </summary>
        public string GetScore()
        {
            if (player1.score == player2.score) return NameEqualScores();
            else if (Scores.Either(s => s >= 4)) return NameLargeScores();
            else return NameUnequalScores();

            //! Creates the score result when the scores are equal
            string NameEqualScores()
            {
                return player1.score < 3
                        ? $"{TennisUtils.MapIndividualScore(player1.score)}{Delimiter}{EqualityLabel}" //! Equal small scores
                        : ScoreLabel.Deuce.ToString(); //! Draw for large scores
            }

            //! Creates the score result when the scores are not equal
            string NameUnequalScores()
            {
                ScoreLabel player1Score = TennisUtils.MapIndividualScore(player1.score);
                ScoreLabel player2Score = TennisUtils.MapIndividualScore(player2.score);
                return $"{player1Score}{Delimiter}{player2Score}";
            }

            //! Creates the score result when the scores are large
            string NameLargeScores()
            {
                int scoreDifference = Math.Abs(player1.score - player2.score);
                return scoreDifference == 1
                        ? $"{ScoreLabel.Advantage} {WinningPlayer.name}"
                        : $"{WinLabel} for {WinningPlayer.name}";
            }
        }
    }
}
