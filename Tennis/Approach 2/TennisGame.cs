using System;

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

        /// <summary> Returns the player with the higher amount of points. </summary>
        internal Player WinningPlayer => player1.score >= player2.score ? player1 : player2;

        /// <summary> Returns the player with the lower amount of points. </summary>
        internal Player LosingPlayer => player1.score >= player2.score ? player2 : player1;

        internal void SetWinningResult(string result)
        {
            if (WinningPlayer.Equals(player1)) player1.result = result;
            else player2.result = result;
        }

        internal void SetLosingResult(string result)
        {
            if (WinningPlayer.Equals(player1)) player2.result = result;
            else player1.result = result;
        }

        /// <summary> Returns <see langword="true"/> if a condition is satisfied by either <see cref="Player"/>. </summary>
        /// <param name="condition"> The condition to be fulfilled by either <see cref="Player"/>. </param>
        internal bool AnyPlayer(Func<Player, Player, bool> condition)
        {
            return condition.Invoke(player1, player2) || condition.Invoke(player2, player1);
        }

        /// <summary> Returns the <see cref="Player"/> who satisfies a condition. </summary>
        /// <param name="condition"> The condition to be fulfilled by a single <see cref="Player"/>. </param>
        internal Player WhichPlayer(Func<Player, Player, bool> condition)
        {
            if (condition.Invoke(player1, player2)) return player1;
            else if (condition.Invoke(player2, player1)) return player2;
            else throw new InvalidOperationException("Neither player satisfied the given condition.");
        }

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            string score = string.Empty;

            //! Equal scores
            if (player1.score == player2.score)
            {
                if (player1.score < 3) score = NameLowScore();
                else if (player1.score > 2) score = NameLowEqual();
            }

            //! Regular scores
            if (AnyPlayer((player, opponent) => player.score > 0 && opponent.score == 0)) 
                score = PlayerLove();
            else if (AnyPlayer((player, opponent) => player.score > opponent.score && player.score < 4)) 
                score = PlayerLowMore();
            else if (AnyPlayer((player, opponent) => player.score > opponent.score && opponent.score >= 3)) 
                score = PlayerHighMore();

            //! Victory conditions
            if (AnyPlayer((player, opponent) => player.score >= 4 && opponent.score >= 0 && (player.score - opponent.score) >= 2)) 
                score = PlayerWin();

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

            string PlayerLove()
            {
                Player winningPlayer = WinningPlayer;
                switch (winningPlayer.score)
                {
                    case 1:
                        SetWinningResult($"{ScoreLabel.Fifteen}");
                        break;
                    case 2:
                        SetWinningResult($"{ScoreLabel.Thirty}");
                        break;
                    case 3:
                        SetWinningResult($"{ScoreLabel.Forty}");
                        break;
                }

                SetLosingResult($"{ScoreLabel.Love}");

                score = player1.result + Delimiter + player2.result;
                return score;
            }

            string PlayerLowMore()
            {
                Player winningPlayer = WinningPlayer;
                Player losingPlayer = LosingPlayer;

                switch (winningPlayer.score)
                {
                    case 2:
                        SetWinningResult($"{ScoreLabel.Thirty}");
                        break;
                    case 3:
                        SetWinningResult($"{ScoreLabel.Forty}");
                        break;
                }

                switch (losingPlayer.score)
                {
                    case 1:
                        SetLosingResult($"{ScoreLabel.Fifteen}");
                        break;
                    case 2:
                        SetLosingResult($"{ScoreLabel.Thirty}");
                        break;
                }
                score = player1.result + $"{Delimiter}" + player2.result;
                return score;
            }

            string PlayerHighMore()
            {
                score = $"{ScoreLabel.Advantage} {WinningPlayer.name}";
                return score;
            }

            string PlayerWin()
            {
                score = $"{ScoreLabel.Win} for {WinningPlayer}";
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
