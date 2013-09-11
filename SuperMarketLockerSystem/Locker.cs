
using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker : IBagKeeper
    {
        private Dictionary<Ticket, Bag> boxes = new Dictionary<Ticket, Bag>();
        public int Capacity { get; set; }
        private readonly int totalCapacity;

        public Locker(int capacity)
        {
            Capacity = capacity;
            totalCapacity = capacity;
        }

        public bool IsFull()
        {
             return Capacity <= 0; 
        }

        public double VacancyRate
        {
            get { return totalCapacity != 0 ? Capacity/(double) totalCapacity : 0; }
        }

        public Ticket Store(Bag bag)
        {
            if (Capacity > 0)
            {
                Ticket ticket = new Ticket();
                boxes.Add(ticket, bag);
                Capacity--;
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
                Capacity++;
                return bag;
            }
            return null;
        }
    }
}
