using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SmartRobot : Robot
    {
        public SmartRobot(List<Locker> managedLockers) : base(managedLockers)
        {
        }

        protected override Locker GetLocker()
        {
            return lockers.OrderByDescending(t => t.Capacity).First();
        }
    }
}