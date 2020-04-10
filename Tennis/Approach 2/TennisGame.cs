namespace Tennis.SecondApproach
{
    public class TennisGame : ITennisGame
    {
        /// <summary> The suffix to use when both player scores are equal. </summary>
        public const string EqualityLabel = "All";
        /// <summary> The delimiter to separate the scores with. </summary>
        public const string Delimiter = "-";

        Player player1;
        Player player2;

        string player1Result = string.Empty;
        string player2Result = string.Empty;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            string score = string.Empty;
            if (player1.score == player2.score)
            {
                if (player1.score < 3) score = NameLowScore();
                else if (player1.score > 2) score = NameLowEqual();
            }

            if (player1.score > 0 && player2.score == 0) score = Player2Love();
            if (player2.score > 0 && player1.score == 0) score = Player1Love();

            if (player1.score > player2.score && player1.score < 4) score = Player1LowMore();
            if (player2.score > player1.score && player2.score < 4) score = Player2LowMore();

            if (player1.score > player2.score && player2.score >= 3) score = Player1HighMore();
            if (player2.score > player1.score && player1.score >= 3) score = Player2HighMore();

            if (player1.score >= 4 && player2.score >= 0 && (player1.score - player2.score) >= 2) score = Player1Win();
            if (player2.score >= 4 && player1.score >= 0 && (player2.score - player1.score) >= 2) score = Player2Win();
            return score;

            string NameLowScore()
            {
                switch (player1.score)
                {
                    case 0:
                        score = $"{ScoreLabel.Love}";
                        break;
                    case 1:
                        score = $"{ScoreLabel.Fifteen}";
                        break;
                    case 2:
                        score = $"{ScoreLabel.Thirty}";
                        break;
                }
                score += $"{Delimiter}{EqualityLabel}";
                return score;
            }

            string Player2Love()
            {
                switch (player1.score)
                {
                    case 1:
                        player1Result = $"{ScoreLabel.Fifteen}";
                        break;
                    case 2:
                        player1Result = $"{ScoreLabel.Thirty}";
                        break;
                    case 3:
                        player1Result = $"{ScoreLabel.Forty}";
                        break;
                }

                player2Result = $"{ScoreLabel.Love}";
                score = player1Result + Delimiter + player2Result;
                return score;
            }

            string Player1Love()
            {
                switch (player2.score)
                {
                    case 1:
                        player2Result = $"{ScoreLabel.Fifteen}";
                        break;
                    case 2:
                        player2Result = $"{ScoreLabel.Thirty}";
                        break;
                    case 3:
                        player2Result = $"{ScoreLabel.Forty}";
                        break;
                }

                player1Result = $"{ScoreLabel.Love}";
                score = player1Result + Delimiter + player2Result;
                return score;
            }

            string Player1LowMore()
            {
                switch (player1.score)
                {
                    case 2:
                        player1Result = $"{ScoreLabel.Thirty}";
                        break;
                    case 3:
                        player1Result = $"{ScoreLabel.Forty}";
                        break;
                }

                switch (player2.score)
                {
                    case 1:
                        player2Result = $"{ScoreLabel.Fifteen}";
                        break;
                    case 2:
                        player2Result = $"{ScoreLabel.Thirty}";
                        break;
                }
                score = player1Result + $"{Delimiter}" + player2Result;
                return score;
            }

            string Player2LowMore()
            {
                switch (player2.score)
                {
                    case 2:
                        player2Result = $"{ScoreLabel.Thirty}";
                        break;
                    case 3:
                        player2Result = $"{ScoreLabel.Forty}";
                        break;
                }
                switch (player1.score)
                {
                    case 1:
                        player1Result = $"{ScoreLabel.Fifteen}";
                        break;
                    case 2:
                        player1Result = $"{ScoreLabel.Thirty}";
                        break;
                }
                score = player1Result + Delimiter + player2Result;
                return score;
            }

            string Player1HighMore()
            {
                score = $"{ScoreLabel.Advantage} {player1.name}";
                return score;
            }

            string Player2HighMore()
            {
                score = $"{ScoreLabel.Advantage} {player2.name}";
                return score;
            }

            string Player1Win()
            {
                score = $"{ScoreLabel.Win} for {player1.name}";
                return score;
            }

            string Player2Win()
            {
                score = $"{ScoreLabel.Win} for {player2.name}";
                return score;
            }

            string NameLowEqual()
            {
                return $"{ScoreLabel.Deuce}";
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.name) player1.AddPoints();
            else player2.AddPoints();
        }
    }
}
