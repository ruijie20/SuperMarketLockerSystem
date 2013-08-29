using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SmartRobot
    {
        List<Locker> lockers = new List<Locker>();
        private int lockerCount;

        public SmartRobot(List<Locker> manageLockers)
        {
            lockerCount = manageLockers.Count;
            for (int i = 0; i < manageLockers.Count; i++)
            {
                lockers.Add(manageLockers[i]);
            }
        }

        public Ticket Store(Bag bag)
        {
            var locker = lockers.OrderByDescending(t => t.capacity).First();
            
            if(locker.IsFull)
                throw new ArgumentException("The lockers are full!");
            return locker.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}