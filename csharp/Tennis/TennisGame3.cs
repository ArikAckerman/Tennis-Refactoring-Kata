namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player1Points;
        private int player2Points;
        private string player1Name;
        private string player2Name;
        public static readonly string[] POINTS_NAMES = new[] { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (IsNotEndGame())
            {
                return GetRegularScore();
            }
            else
            {
                if (IsDeuce())
                {
                    return "Deuce";
                }

                string leader = (player1Points > player2Points) ? player1Name : player2Name;

                if (IsAdvantage())
                {
                    return "Advantage " + leader;
                }
                else
                {
                    return "Win for " + leader;
                }
            }
        }

        private bool IsNotEndGame()
        {
            return (player1Points < 4 && player2Points < 4) && (player1Points + player2Points < 6);
        }

        private string GetRegularScore()
        {
            if (player1Points == player2Points)
            {
                return POINTS_NAMES[player1Points] + "-All";
            }
            else
            {
                return POINTS_NAMES[player1Points] + "-" + POINTS_NAMES[player2Points];
            }
        }

        private bool IsDeuce()
        {
            return player1Points == player2Points;
        }

        private bool IsAdvantage()
        {
            int pointsDifference = player1Points - player2Points;
            return Math.Abs(pointsDifference) == 1;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                player1Points += 1;
            }
            else
            {
                player2Points += 1;
            }
        }
    }
}


