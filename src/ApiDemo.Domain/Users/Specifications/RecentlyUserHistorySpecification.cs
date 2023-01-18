using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace ApiDemo.Users
{
    public class RecentlyUserHistorySpecification
    {
        public Func<UserHistory, bool> ToExpression()
        {
            var daysRecently = DateTime.Now.Subtract(TimeSpan.FromDays(5));
            return (userHistory) => (userHistory.Date >= daysRecently);
        }
    }
}