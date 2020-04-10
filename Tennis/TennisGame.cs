using System;
using System.Linq;

namespace Tennis
{
    /// <summary> A single game of tennis. </summary>
    class TennisGame : ITennisGame
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

            /// <summary> Adds a point to the player's <see cref="score"/>. </summary>
            public void AddPoint() => score++;

            /// <summary>Returns the name of the player.</summary>
            public override string ToString() => $"{name}";
        }

        Player player1;
        Player player2;

        /// <summary> The result of a game, based on <see cref="Player">players'</see> scores. </summary>
        struct Result
        {
            /// <summary> All the possible score denominators. </summary>
            enum Scores
            {
                /// <summary> Zero points. </summary>
                Love,
                /// <summary> One point. </summary>
                Fifteen,
                /// <summary> Two points. </summary>
                Thirty,
                /// <summary> Three points. </summary>
                Forty,
                /// <summary> Equal number of points over three. </summary>
                Deuce,
                /// <summary> Unequal number of points over three. </summary>
                Advantage
            }

            /// <summary> The scores of both opponents. </summary>
            (int, int) scores;

            /// <summary> Creates a new game <see cref="Result"/>. </summary>
            /// <param name="score1"> The score of the first <see cref="Player"/>. </param>
            /// <param name="score2"> The score of the <see cref="Player">opponent</see>.</param>
            public Result(int score1, int score2)
            {
                scores = (score1, score2);
            }

            /// <summary> Creates a new game <see cref="Result"/>. </summary>
            /// <param name="player1"> The first <see cref="Player"/>. </param>
            /// <param name="player2"> The second <see cref="Player"/>.</param>
            public Result(Player player1, Player player2) : this(player1.score, player2.score) { }

            /// <summary>Returns the fully qualified type name of this instance.</summary>
            /// <returns>The fully qualified type name.</returns>
            public override string ToString()
            {
                bool Both<T>(ValueTuple<T, T> pair) => false;
                throw new NotImplementedException($"{nameof(ToString)} method isn't fully implemented yet.");
            }
        }

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

    /// <summary> Additional helper methods for simplifying tennis score displaying. </summary>
    static class TennisExtensions
    {
        /// <summary> Checks if both elements of a tuple pair conform to a condition. </summary>
        /// <typeparam name="T"> The type of the tuple. </typeparam>
        /// <param name="pair"> The pair. </param>
        /// <param name="condition"> The condition to be satisfied by both elements of the pair. </param>
        /// <returns></returns>
        public static bool Both<T>(this (T first, T second) pair, Predicate<T> condition)
        {
            (T first, T second) = pair;
            return condition.Invoke(first) && condition.Invoke(second);
        }
    }
}
