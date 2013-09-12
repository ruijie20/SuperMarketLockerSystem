using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    public class SuperRobotTest
    {
        [Test]
        public void should_select_the_highest_vacancy_rate_locker_when_store_bag()
        {
            var locker1 = new Locker(3);
            var locker2 = new Locker(2);
            var superRobot = new SuperRobot(
                new List<IBagKeeper>
                    {
                        locker1,
                        locker2
                    });

            locker1.Store(new Bag());
            var bag = new Bag();
            Ticket ticket = superRobot.Store(bag);

            Assert.AreSame(bag, locker2.Pick(ticket));
        }
    }
}
