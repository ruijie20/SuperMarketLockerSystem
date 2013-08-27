
using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private Dictionary<Ticket, Bag> bags = new Dictionary<Ticket, Bag>();
        public bool isFull = false;

        public Ticket Store(Bag bag)
        {
            if (!isFull)
            {
                Ticket ticket = new Ticket();
                bags.Add(ticket, bag);
                isFull = true;
                return ticket;
            }
            throw new ArgumentException("The locker is full!");
        }

        public Bag Pick(Ticket ticket)
        {
            if (bags.ContainsKey(ticket))
            {
                var bag = bags[ticket];
                bags.Remove(ticket);
                isFull = false;
                return bag;
            }
            return null;
        }
    }
}
