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
            for (int i = 0; i < managedLockers.Count; i++)
            {
                lockers.Add(managedLockers[i]);
            }

            lockerCount = managedLockers.Count;
        }

        public Ticket Store(Bag bag)
        {
            for (int num = 0; num < lockerCount; num++)
            {
                if (lockers[num].IsFull)
                    continue;

                return lockers[num].Store(bag);
            }
            throw new ArgumentException("The lockers are full!");
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}