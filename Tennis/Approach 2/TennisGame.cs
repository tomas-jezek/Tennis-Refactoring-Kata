namespace Tennis.SecondApproach
{
    public class TennisGame : ITennisGame
    {
        int player1Points;
        int player2Points;

        string player1Result = string.Empty;
        string player2Result = string.Empty;
        readonly string player1Name;
        readonly string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            player1Points = 0;
            this.player2Name = player2Name;
            //? Why not player 2 points?!
        }

        public string GetScore()
        {
            string score = string.Empty;
            if (player1Points == player2Points && player1Points < 3)
            {
                switch (player1Points) {
                    case 0:
                        score = "Love";
                        break;
                    case 1:
                        score = "Fifteen";
                        break;
                    case 2:
                        score = "Thirty";
                        break;
                }
                score += "-All";
            }
            if (player1Points == player2Points && player1Points > 2)
                score = "Deuce";

            if (player1Points > 0 && player2Points == 0)
            {
                switch (player1Points) {
                    case 1:
                        player1Result = "Fifteen";
                        break;
                    case 2:
                        player1Result = "Thirty";
                        break;
                    case 3:
                        player1Result = "Forty";
                        break;
                }

                player2Result = "Love";
                score = player1Result + "-" + player2Result;
            }
            if (player2Points > 0 && player1Points == 0)
            {
                switch (player2Points) {
                    case 1:
                        player2Result = "Fifteen";
                        break;
                    case 2:
                        player2Result = "Thirty";
                        break;
                    case 3:
                        player2Result = "Forty";
                        break;
                }

                player1Result = "Love";
                score = player1Result + "-" + player2Result;
            }

            if (player1Points > player2Points && player1Points < 4)
            {
                switch (player1Points) {
                    case 2:
                        player1Result = "Thirty";
                        break;
                    case 3:
                        player1Result = "Forty";
                        break;
                }

                switch (player2Points) {
                    case 1:
                        player2Result = "Fifteen";
                        break;
                    case 2:
                        player2Result = "Thirty";
                        break;
                }
                score = player1Result + "-" + player2Result;
            }
            if (player2Points > player1Points && player2Points < 4)
            {
                switch (player2Points) {
                    case 2:
                        player2Result = "Thirty";
                        break;
                    case 3:
                        player2Result = "Forty";
                        break;
                }
                switch (player1Points) {
                    case 1:
                        player1Result = "Fifteen";
                        break;
                    case 2:
                        player1Result = "Thirty";
                        break;
                }
                score = player1Result + "-" + player2Result;
            }

            if (player1Points > player2Points && player2Points >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Points > player1Points && player1Points >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Points >= 4 && player2Points >= 0 && (player1Points - player2Points) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Points >= 4 && player1Points >= 0 && (player2Points - player1Points) >= 2)
            {
                score = "Win for player2";
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
            if (playerName == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

