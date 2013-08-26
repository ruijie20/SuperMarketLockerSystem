
using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        public Dictionary<Ticket, Bag> bags = new Dictionary<Ticket, Bag>();
        private readonly int BAG_MAX_NUM = 1;

        public Ticket Store(Bag bag)
        {
            if (bags.Count < BAG_MAX_NUM)
            {
                Ticket ticket = new Ticket("ticket");
                bags.Add(ticket, bag);
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
                return bag;
            }
            return null;
        }
    }
}
