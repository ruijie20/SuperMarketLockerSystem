using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Manager
    {
        private readonly List<IBagKeeper> bagKeepers = new List<IBagKeeper>();

        public Manager(List<IBagKeeper> bagKeeperList)
        {
            foreach (var bagKeeper in bagKeeperList)
            {
                bagKeepers.Add(bagKeeper);
            }
        }

        public Ticket Store(Bag bag)
        {
            if (bagKeepers.Count == 0)
            {
                throw new ArgumentException("No locker or robot available");
            }
            var bagKeeper = GetBagKeeper();
            if (bagKeeper != null)
            {
                return bagKeeper.Store(bag);
            }
            throw new ArgumentException("The manager is full!");
        }

        protected IBagKeeper GetBagKeeper()
        {
            return bagKeepers.FirstOrDefault(t => !t.IsFull());
        }

        public Bag Pick(Ticket ticket)
        {
            return bagKeepers.Select(bagKeeper => bagKeeper.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}