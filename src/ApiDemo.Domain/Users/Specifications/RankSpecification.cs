using System;

namespace ApiDemo.Users
{
    public class RankSpecification
    {
        public Func<double, Ranking> ToExpression()
        {
            return (TotalReadingTime) =>
            {
                switch (TotalReadingTime)
                {
                    case < 50:
                        return Ranking.Bronze;
                    case < 500:
                        return Ranking.Silver;
                    default:
                        return Ranking.Gold;
                }
            };
        }
    }
}