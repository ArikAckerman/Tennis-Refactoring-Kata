using System;

namespace Tennis
{
    public class TennisGame5 : ITennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame5(string player1Name, string player2Name)
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
            int p1 = Math.Min(player1Score, 4);
            int p2 = Math.Min(player2Score, 4);

            return (p1, p2) switch
            {
                (0, 0) => "Love-All",
                (0, 1) => "Love-Fifteen",
                (0, 2) => "Love-Thirty",
                (0, 3) => "Love-Forty",
                (1, 0) => "Fifteen-Love",
                (1, 1) => "Fifteen-All",
                (1, 2) => "Fifteen-Thirty",
                (1, 3) => "Fifteen-Forty",
                (2, 0) => "Thirty-Love",
                (2, 1) => "Thirty-Fifteen",
                (2, 2) => "Thirty-All",
                (2, 3) => "Thirty-Forty",
                (3, 0) => "Forty-Love",
                (3, 1) => "Forty-Fifteen",
                (3, 2) => "Forty-Thirty",
                (3, 3) => "Deuce",
                _ => GetAdvantageOrWinScore(p1, p2)
            };
        }

        private string GetAdvantageOrWinScore(int p1, int p2)
        {
            int scoreDifference = Math.Abs(p1 - p2);

            if (scoreDifference == 0)
            {
                return "Deuce";
            }
            else if (scoreDifference == 1)
            {
                string leader = (p1 > p2) ? player1Name : player2Name;
                return "Advantage " + leader;
            }
            else
            {
                string winner = (p1 > p2) ? player1Name : player2Name;
                return "Win for " + winner;
            }
        }
    }
}
