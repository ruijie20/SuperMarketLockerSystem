using System;
using System.Collections.Generic;
using System.Linq;

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
            Ticket ticket = null;
            for (int num = 0; num < lockers.Count; num++)
            {
                if (lockers[num].IsFull)
                    throw new ArgumentException("The lockers are full!");
                else
                    ticket = lockers[num].Store(bag);
            }
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}