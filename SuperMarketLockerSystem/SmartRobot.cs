using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SmartRobot : Robot
    {
        public SmartRobot(List<IBagKeeper> managedLockers) : base(managedLockers)
        {
        }

        protected override IBagKeeper GetLocker()
        {
            return lockers.OrderByDescending(t => t.Capacity).FirstOrDefault(t => !t.IsFull());
        }
    }
}