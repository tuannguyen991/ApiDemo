using System;

namespace ApiDemo.Users
{
    public class RatingSpecification
    {
        public Func<UserLibrary, double> ToExpression()
        {
            return userLibrary =>
            {
                double rating = (userLibrary.IsFavorite ? 5 : 0) + (userLibrary.ReadCount);
                return rating;
            };
        }
    }
}