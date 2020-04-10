namespace Tennis.SecondApproach
{
    public class TennisGame : ITennisGame
    {
        public const string EqualityLabel = "All";
        public const string Delimiter = "-";

        int player1Points = 0;
        int player2Points = 0;

        readonly string player1Name;
        readonly string player2Name;

        string player1Result = string.Empty;
        string player2Result = string.Empty;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score = string.Empty;
            if (player1Points == player2Points && player1Points < 3)
            {
                switch (player1Points)
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
            if (player1Points == player2Points && player1Points > 2) score = $"{ScoreLabel.Deuce}";

            if (player1Points > 0 && player2Points == 0)
            {
                switch (player1Points)
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
            if (player2Points > 0 && player1Points == 0)
            {
                switch (player2Points)
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

            if (player1Points > player2Points && player1Points < 4)
            {
                switch (player1Points)
                {
                    case 2:
                        player1Result = $"{ScoreLabel.Thirty}";
                        break;
                    case 3:
                        player1Result = $"{ScoreLabel.Forty}";
                        break;
                }

                switch (player2Points)
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
            if (player2Points > player1Points && player2Points < 4)
            {
                switch (player2Points)
                {
                    case 2:
                        player2Result = $"{ScoreLabel.Thirty}";
                        break;
                    case 3:
                        player2Result = $"{ScoreLabel.Forty}";
                        break;
                }
                switch (player1Points)
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

            if (player1Points > player2Points && player2Points >= 3)
            {
                score = $"{ScoreLabel.Advantage} {player1Name}";
            }

            if (player2Points > player1Points && player1Points >= 3)
            {
                score = $"{ScoreLabel.Advantage} {player2Name}";
            }

            if (player1Points >= 4 && player2Points >= 0 && (player1Points - player2Points) >= 2)
            {
                score = $"{ScoreLabel.Win} for {player1Name}";
            }
            if (player2Points >= 4 && player1Points >= 0 && (player2Points - player1Points) >= 2)
            {
                score = $"{ScoreLabel.Win} for {player2Name}";
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
            player1Points++;
        }

        private void P2Score()
        {
            player2Points++;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name) P1Score();
            else P2Score();
        }
    }
}
