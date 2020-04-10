using System;
using JetBrains.Annotations;

namespace Tennis.FirstApproach
{
    /// <summary> A single game of tennis. </summary>
    class TennisGame : ITennisGame
    {
        Player player1;
        Player player2;

        /// <summary> Gets the player with the higher score. </summary>
        public Player WinningPlayer => TennisUtils.GetWinningPlayer(player1, player2);

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
        public string GetScore() => GetScore("{0}-{1}");

        /// <summary> Constructs a string summarising the score. </summary>
        /// <param name="format"> Specify the position of score labels ({0},{1}) and the delimiter. </param>
        [StringFormatMethod("format")]
        public string GetScore(string format)
        {
            if (player1.score == player2.score) return NameEqualScores();
            else if (player1.score >= 4 || player2.score >= 4) return NameLargeScores();
            else return NameUnequalScores();

            //! Creates the score result when the scores are equal
            string NameEqualScores()
            {
                return player1.score < 3
                        ? $"{Result.MapLowScore(player1.score)}-{Result.EqualityLabel}"
                        : Scores.Deuce.ToString();
            }

            //! Creates the score result when the scores are not equal
            string NameUnequalScores()
            {
                Scores scoreLabel1 = Result.MapLowScore(player1.score);
                Scores scoreLabel2 = Result.MapLowScore(player2.score);
                return $"{scoreLabel1}-{scoreLabel2}";
            }

            //! Creates the score result when the scores are large
            string NameLargeScores()
            {
                int scoreDifference = Math.Abs(player1.score - player2.score);
                return scoreDifference == 1 
                        ? $"{Scores.Advantage} {WinningPlayer.name}" 
                        : $"{Result.WinLabel} for {WinningPlayer.name}";
            }
        }
    }
}
