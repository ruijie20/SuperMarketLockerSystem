using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Manager
    {
        protected readonly List<Locker> lockers = new List<Locker>();
        protected readonly List<Robot> robots = new List<Robot>();

        public Manager(List<Locker> managedLockers)
        {
            foreach (var t in managedLockers)
            {
                lockers.Add(t);
            }
        }

        public Manager(List<Robot> robotList)
        {
            foreach (var robot in robotList)
            {
                robots.Add(robot);
            }
        }

        public Ticket Store(Bag bag)
        {
            if (lockers.Count == 0)
            {
                for (var i = 0; i < robots.Count; i++)
                {
                    Ticket ticket = robots[i].Store(bag);
                    if (ticket != null)
                    {
                        return ticket;
                    }
                }
            }
            var locker = GetLocker();
            if (locker != null)
            {
                return locker.Store(bag);
            }
            throw new ArgumentException("The lockers are full!");
        }

        protected virtual Locker GetLocker()
        {
            return lockers.FirstOrDefault(t => !t.IsFull);
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}