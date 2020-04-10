namespace Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName); // 'String' is stupid, but since changing this would change the logic…
        string GetScore();
    }
}

