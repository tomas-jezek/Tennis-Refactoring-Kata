namespace Tennis
{
    /// <summary> A single game of tennis. </summary>
    class Game : ITennisGame
    {
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

        public Game(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1") player1.score += 1;
            else player2.score += 1;
        }

        public string GetScore()
        {
            string score = "";
            if (player1.score == player2.score)
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
            }
            else if (player1.score >= 4 || player2.score >= 4)
            {
                var minusResult = player1.score - player2.score;
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
            }
            return score;
        }
    }
}
