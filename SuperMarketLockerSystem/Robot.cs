using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Robot : IBagKeeper
    {
        protected readonly List<IBagKeeper> lockers = new List<IBagKeeper>();

        public Robot(List<IBagKeeper> managedLockers)
        {
            foreach (var t in managedLockers)
            {
                lockers.Add(t);
            }
        }

        public Ticket Store(Bag bag)
        {
            if (lockers.Count == 0)
            {
                throw new ArgumentException("No locker is available");
            }
            var locker = GetLocker();
            if (locker != null)
            {
                return locker.Store(bag);
            }
            throw new ArgumentException("The lockers are full!");
        }

        protected virtual IBagKeeper GetLocker()
        {
            return lockers.FirstOrDefault(t => !t.IsFull());
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }

        public int Capacity { get; private set; }
        public double VacancyRate { get; private set; }

        public bool IsFull()
        {
            if (lockers.Count == 0)
            {
                return true;
            }
            return GetLocker() == null;
        }
    }
}