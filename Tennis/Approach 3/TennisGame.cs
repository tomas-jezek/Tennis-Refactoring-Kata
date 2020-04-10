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

        static readonly string[] Labels = new[] {ScoreLabel.Love, ScoreLabel.Fifteen, ScoreLabel.Thirty, ScoreLabel.Forty}
                                         .Select(lb => lb.ToString()).ToArray();

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            //! Low
            bool lowAmountOfPoints = (player1, player2).Both(p => p.score < 4) 
                                  && (player1.score + player2.score < 6);
            if (lowAmountOfPoints)
            {
                return MapPointsToResult(player1.score, player2.score);
            }
            else
            {
                //! Equal large
                bool equalPoints = player1.score == player2.score;
                if (equalPoints) return ScoreLabel.Deuce.ToString();

                //! Unequal large
                string result = player1.score > player2.score 
                        ? player1.name : player2.name;

                bool differenceIsSmall = (player1.score - player2.score) * (player1.score - player2.score) == 1;
                return (differenceIsSmall) 
                        ? $"{ScoreLabel.Advantage} " + result 
                        : $"{ScoreLabel.Win} for " + result;
            }

            string MapPointsToResult(int score1, int score2)
            {
                string secondLabel = score1 == score2
                        ? EqualityLabel
                        : Labels[score2];
                return $"{Labels[score1]}{Delimiter}{secondLabel}";
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.name) player1.AddPoints();
            else player2.AddPoints();
        }
    }
}
