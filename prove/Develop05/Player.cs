class Player
{
    private int _score;

    public Player(int score)
    {
        _score = score;
    }

    public void AddScore(int points)
    {
        _score += points;
    }

    public int GetScore()
    {
        return _score;
    }

    public string GetRank()
    {
        int rank = _score / 500;
        string rankIndicator = "";

        if (rank > 10)
        {
            rankIndicator = "+" + (rank - 10);
        }

        switch (rank % 11)
        {
            case 0:
                return "Novice" + rankIndicator;
            case 1:
                return "Amateur" + rankIndicator;
            case 2:
                return "Skilled" + rankIndicator;
            case 3:
                return "Expert" + rankIndicator;
            case 4:
                return "Master" + rankIndicator;
            case 5:
                return "Grandmaster" + rankIndicator;
            case 6:
                return "Legendary" + rankIndicator;
            case 7:
                return "Mythical" + rankIndicator;
            case 8:
                return "Celestial" + rankIndicator;
            case 9:
                return "Transcendent" + rankIndicator;
            case 10:
                return "Infinite" + rankIndicator;
            default:
                return "Invalid Rank";
        }
    }
}