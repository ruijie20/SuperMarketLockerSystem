
using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private List<Bag> bags = new List<Bag>();
        private readonly int BAG_MAX_NUM = 1;

        public Ticket Store(Bag bag)
        {
            if (bags.Count < BAG_MAX_NUM)
            {
                bags.Add(bag);
                return new Ticket();
            }
            throw new ArgumentException("The locker is full!");
        }
    }
}
