namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int score1 = 0;
        private int score2 = 0;
        private string player1Name;
        private string player2Name;

        /// <summary> The representation of a tennis player. </summary>
        struct Player
        {
            /// <summary> The name of the player. </summary>
            public string name;
            /// <summary> Current score of the player in the game. </summary>
            public int score;

            /// <summary> Creates a new <see cref="Player"/>. </summary>
            /// <param name="name"> The name of the player. </param>
            /// <remarks> The score is initially set to zero. </remarks>
            public Player(string name)
            {
                this.name = name;
                this.score = 0;
            }

            /// <summary>Returns the name of the player.</summary>
            public override string ToString() => $"{name}";
        }

        Player player1;
        Player player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                score1 += 1;
            else
                score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            {
                switch (score1)
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
            }
            else if (score1 >= 4 || score2 >= 4)
            {
                var minusResult = score1 - score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    else { score += "-"; tempScore = score2; }
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
            }
            return score;
        }
    }
}

