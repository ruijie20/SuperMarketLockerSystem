using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SuperRobot : Robot
    {
        public SuperRobot(List<Locker> lockers)
            : base(lockers)
        {
        }

        protected override Locker GetLocker()
        {
            return lockers.OrderByDescending(t => t.VacancyRate).First();
        }
    }
}