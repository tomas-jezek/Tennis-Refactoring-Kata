namespace Tennis.ThirdApproach
{
    /// <summary> All the possible score denominators. </summary>
    public enum ScoreLabel
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
        Advantage,
        /// <summary> One has won the game. </summary>
        Win
    }
}
