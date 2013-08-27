using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Robot
    {
        private List<Locker> lockers = new List<Locker>();
        private int currentLokerNum = 0;
        private int lockerCount;

        public Robot(int lockerCount)
        {
            lockerCount = lockerCount;
            for (int num = 0; num < lockerCount; num++)
            {
                lockers.Add(new Locker());
            }
        }

        public Ticket Store(Bag bag)
        {
            for (int num = 0; num < lockers.Count; num++)
            {
                if (!lockers[num].isFull)
                {
                    var ticket = lockers[num].Store(bag);
                    currentLokerNum++;
                    return ticket;
                }
            }
            throw new ArgumentException("The lockers are full!");
        }

        public Bag Pick(Ticket ticket)
        {
            foreach (Locker locker in lockers)
            {
                Bag bag = locker.Pick(ticket);
                if (bag != null)
                {
                    currentLokerNum--;
                    return bag;
                }
            }
            return null;
        }
    }
}