
using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private Dictionary<Ticket, Bag> boxes = new Dictionary<Ticket, Bag>();
        private int capacity = 10;

        public bool IsFull
        {
            get { return capacity <= 0; } 
        }

        public Ticket Store(Bag bag)
        {
            if (capacity > 0)
            {
                Ticket ticket = new Ticket();
                boxes.Add(ticket, bag);
                capacity--;
                return ticket;
            }
            throw new ArgumentException("The locker is full!");
        }

        public Bag Pick(Ticket ticket)
        {
            if (boxes.ContainsKey(ticket))
            {
                var bag = boxes[ticket];
                boxes.Remove(ticket);
                capacity++;
                return bag;
            }
            return null;
        }
    }
}
