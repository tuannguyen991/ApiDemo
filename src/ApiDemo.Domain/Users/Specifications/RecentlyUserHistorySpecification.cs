using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace ApiDemo.Users
{
    public class RecentlyUserHistorySpecification
    {
        public Func<UserHistory, bool> ToExpression()
        {
            int days = 15;
            var daysRecently = DateTime.Now.Subtract(TimeSpan.FromDays(days));
            return (userHistory) => (userHistory.Date >= daysRecently);
        }
    }
}