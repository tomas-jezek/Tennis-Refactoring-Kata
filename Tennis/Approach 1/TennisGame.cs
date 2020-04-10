using System;
using JetBrains.Annotations;

namespace Tennis.FirstApproach {
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
            string score = string.Empty;
            if (player1.score == player2.score)
            {
                score = NameEqualScores();
            }
            else if (player1.score >= 4 || player2.score >= 4)
            {
                score = NameLargeScores();
            }
            else
            {
                score = NameUnequalScores();
            }
            return score;

            //! Creates the score result when the scores are equal
            string NameEqualScores()
            {
                // TODO: Use Format
                switch (player1.score)
                {
                    case 0:
                        score = $"{Scores.Love}-{Result.EqualityLabel}";
                        break;
                    case 1:
                        score = $"{Scores.Fifteen}-{Result.EqualityLabel}";
                        break;
                    case 2:
                        score = $"{Scores.Thirty}-{Result.EqualityLabel}";
                        break;
                    default:
                        score = $"{Scores.Deuce}";
                        break;
                }
                return score;
            }

            //! Creates the score result when the scores are not equal
            string NameUnequalScores()
            {
                // TODO: Use Format
                for (int i = 1; i < 3; i++)
                {
                    if (i == 1)
                    {
                        score += Result.MapRegularScore(player1.score);
                    }
                    else
                    {
                        score += "-";
                        score += Result.MapRegularScore(player2.score);
                    }
                }
                return score;
            }

            //! Creates the score result when the scores are large
            string NameLargeScores()
            {
                int scoreDifference = Math.Abs(player1.score - player2.score);
                switch (scoreDifference)
                {
                    case 0:
                        // TODO: Move 'Deuce' here
                        break;
                    case 1:
                        score = $"{Scores.Advantage} {WinningPlayer.name}";
                        break;
                    default:
                        score = $"{Result.WinLabel} for {WinningPlayer.name}";
                        break;
                }
                return score;
            }
        }
    }
}
