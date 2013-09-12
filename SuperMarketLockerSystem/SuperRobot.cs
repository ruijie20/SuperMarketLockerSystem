using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SuperRobot : Robot
    {
        public SuperRobot(List<IBagKeeper> lockers)
            : base(lockers)
        {
        }

        protected override IBagKeeper GetLocker()
        {
            return lockers.OrderByDescending(t => t.VacancyRate).FirstOrDefault(t => !t.IsFull());
        }
    }
}