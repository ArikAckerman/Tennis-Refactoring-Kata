namespace Tennis
{
    public class TennisGame6 : ITennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame6(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                player1Score++;
            else if (playerName == player2Name)
                player2Score++;
            else
                throw new ArgumentException("Invalid player name.");
        }

        public string GetScore()
        {
            if (IsTieScore())
            {
                return GetTieScore();
            }
            else if (IsEndGameScore())
            {
                return GetEndGameScore();
            }
            else
            {
                return GetRegularScore();
            }
        }

        private bool IsTieScore()
        {
            return player1Score == player2Score;
        }

        private string GetTieScore()
        {
            if (player1Score <= 2)
            {
                return $"{GetScoreName(player1Score)}-All";
            }
            else
            {
                return "Deuce";
            }
        }

        private bool IsEndGameScore()
        {
            return player1Score >= 4 || player2Score >= 4;
        }

        private string GetEndGameScore()
        {
            int scoreDifference = player1Score - player2Score;
            string leader = (scoreDifference > 0) ? player1Name : player2Name;

            if (Math.Abs(scoreDifference) == 1)
            {
                return $"Advantage {leader}";
            }
            else
            {
                return $"Win for {leader}";
            }
        }

        private string GetRegularScore()
        {
            string score1 = GetScoreName(player1Score);
            string score2 = GetScoreName(player2Score);

            return $"{score1}-{score2}";
        }

        private string GetScoreName(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };
        }
    }
}
