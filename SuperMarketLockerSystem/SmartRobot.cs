using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SmartRobot : Robot
    {
        public SmartRobot(List<Locker> managedLockers) : base(managedLockers)
        {
        }

        public override Ticket Store(Bag bag)
        {
            if (lockers.Count == 0)
            {
                throw new ArgumentException("No locker is available");
            }
            IOrderedEnumerable<Locker> orderByDescending = lockers.OrderByDescending(t => t.capacity);
            var locker = orderByDescending.First();
            
            if(locker.IsFull)
                throw new ArgumentException("The lockers are full!");
            return locker.Store(bag);
        }
    }
}