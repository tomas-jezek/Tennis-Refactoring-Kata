using System.Linq;

namespace Tennis.ThirdApproach
{
    public class TennisGame : ITennisGame
    {
        /// <summary> The suffix to use when both player scores are equal. </summary>
        public const string EqualityLabel = "All";
        /// <summary> The delimiter to separate the scores with. </summary>
        public const string Delimiter = "-";

        Player player1;
        Player player2;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            string result;
            if (player1.score < 4 && player2.score < 4 && (player1.score + player2.score < 6))
            {
                string[] p = new[] {ScoreLabel.Love, ScoreLabel.Fifteen, ScoreLabel.Thirty, ScoreLabel.Forty}
                            .Select(lb => lb.ToString()).ToArray();
                result = p[player1.score];
                return (player1.score == player2.score)
                        ? result + $"{Delimiter}{EqualityLabel}"
                        : result + Delimiter + p[player2.score];
            }
            else
            {
                if (player1.score == player2.score) return ScoreLabel.Deuce.ToString();
                result = player1.score > player2.score ? player1.name : player2.name;
                return ((player1.score - player2.score) * (player1.score - player2.score) == 1) ? $"{ScoreLabel.Advantage} " + result : $"{ScoreLabel.Win} for " + result;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.name) player1.AddPoints();
            else player2.AddPoints();
        }
    }
}
