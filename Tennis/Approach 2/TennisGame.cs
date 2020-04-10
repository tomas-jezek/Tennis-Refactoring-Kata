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
            if (player1.score == player2.score && player1.score < 3)
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
            }
            if (player1.score == player2.score && player1.score > 2) score = $"{ScoreLabel.Deuce}";

            if (player1.score > 0 && player2.score == 0)
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
            }
            if (player2.score > 0 && player1.score == 0)
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
            }

            if (player1.score > player2.score && player1.score < 4)
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
            }
            if (player2.score > player1.score && player2.score < 4)
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
            }

            if (player1.score > player2.score && player2.score >= 3)
            {
                score = $"{ScoreLabel.Advantage} {player1.name}";
            }

            if (player2.score > player1.score && player1.score >= 3)
            {
                score = $"{ScoreLabel.Advantage} {player2.name}";
            }

            if (player1.score >= 4 && player2.score >= 0 && (player1.score - player2.score) >= 2)
            {
                score = $"{ScoreLabel.Win} for {player1.name}";
            }
            if (player2.score >= 4 && player1.score >= 0 && (player2.score - player1.score) >= 2)
            {
                score = $"{ScoreLabel.Win} for {player2.name}";
            }
            return score;
        }

        public void SetP1Score(int score)
        {
            for (int i = 0; i < score; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int score)
        {
            for (int i = 0; i < score; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            player1.AddPoint();
        }

        private void P2Score()
        {
            player2.AddPoint();
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.name) P1Score();
            else P2Score();
        }
    }
}
