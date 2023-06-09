namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (IsGameTied())
            {
                return GetTiedScore();
            }

            if (IsDeuce())
            {
                return "Deuce";
            }

            if (HasAdvantage())
            {
                return GetAdvantageScore();
            }

            if (HasWinner())
            {
                return GetWinningScore();
            }

            return GetStandardScore();
        }

        private bool IsGameTied()
        {
            return p1point == p2point && p1point < 3;
        }

        private string GetTiedScore()
        {
            string[] scoreOptions = { "Love", "Fifteen", "Thirty" };
            string score = scoreOptions[p1point];
            return $"{score}-All";
        }

        private bool IsDeuce()
        {
            return p1point == p2point && p1point >= 3;
        }

        private bool HasAdvantage()
        {
            return p1point > p2point && p2point >= 3 || p2point > p1point && p1point >= 3;
        }

        private string GetAdvantageScore()
        {
            string leadingPlayer = (p1point > p2point) ? player1Name : player2Name;
            return $"Advantage {leadingPlayer}";
        }

        private bool HasWinner()
        {
            return p1point >= 4 && (p1point - p2point) >= 2 || p2point >= 4 && (p2point - p1point) >= 2;
        }

        private string GetWinningScore()
        {
            string winningPlayer = (p1point > p2point) ? player1Name : player2Name;
            return $"Win for {winningPlayer}";
        }

        private string GetStandardScore()
        {
            string[] scoreOptions = { "Love", "Fifteen", "Thirty", "Forty" };
            string p1res = scoreOptions[p1point];
            string p2res = scoreOptions[p2point];
            return $"{p1res}-{p2res}";
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }
    }
}


