namespace Tennis.FirstApproach {
    /// <summary> A single game of tennis. </summary>
    class TennisGame : ITennisGame
    {
        Player player1;
        Player player2;

        /// <summary> Creates an instance of a new game. </summary>
        /// <param name="player1Name"> The name of the first <see cref="Player"/>. </param>
        /// <param name="player2Name"> The name of the second <see cref="Player"/>. </param>
        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.name) player1.AddPoint();
            else player2.AddPoint();
        }

        public string GetScore()
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
                switch (player1.score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }
                return score;
            }

            //! Creates the score result when the scores are not equal
            string NameUnequalScores()
            {
                for (int i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = player1.score;
                    else
                    {
                        score += "-";
                        tempScore = player2.score;
                    }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
                return score;
            }

            //! Creates the score result when the scores are large
            string NameLargeScores()
            {
                var minusResult = player1.score - player2.score;
                if (minusResult == 1) score = $"Advantage {player1.name}";
                else if (minusResult == -1) score = $"Advantage {player2.name}";
                else if (minusResult >= 2) score = $"Win for {player1.name}";
                else score = $"Win for {player2.name}";
                return score;
            }
        }
    }
}
