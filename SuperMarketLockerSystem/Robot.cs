using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Robot
    {
        protected List<Locker> lockers = new List<Locker>();

        public Robot(List<Locker> managedLockers)
        {
            foreach (var t in managedLockers)
            {
                lockers.Add(t);
            }
        }

        public virtual Ticket Store(Bag bag)
        {
            if (lockers.Count == 0)
            {
                throw new ArgumentException("No locker is available");
            }
            Locker locker = lockers.FirstOrDefault(t => !t.IsFull);
            if (locker != null)
            {
                return locker.Store(bag);
            }
            throw new ArgumentException("The lockers are full!");
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}