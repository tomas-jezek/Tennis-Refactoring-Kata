namespace Tennis.FirstApproach {
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
}
