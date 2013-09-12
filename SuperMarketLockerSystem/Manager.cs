using System;
using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Manager : Robot
    {
        private readonly List<IBagKeeper> bagKeepers = new List<IBagKeeper>();

        public Manager(List<IBagKeeper> bagKeeperList) : base(bagKeeperList)
        {
            foreach (var bagKeeper in bagKeeperList)
            {
                bagKeepers.Add(bagKeeper);
            }
        }
    }
}