using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Robot
    {
        private List<Locker> lockers = new List<Locker>();
        private int lockerCount;

        public Robot(List<Locker> managedLockers)
        {
            foreach (var t in managedLockers)
            {
                lockers.Add(t);
            }

            lockerCount = managedLockers.Count;
        }

        public Ticket Store(Bag bag)
        {
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