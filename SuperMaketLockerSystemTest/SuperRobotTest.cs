using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    public class SuperRobotTest
    {
        [Test]
        public void should_get_a_ticket_when_store_a_bag()
        {
            var superRobot = new SuperRobot(new List<Locker> {new Locker(2)});
            
            Ticket ticket = superRobot.Store(new Bag());
            
            Assert.NotNull(ticket);
        }

        [Test]
        public void show_get_right_back_when_pick_with_ticket()
        {
            var superRobot = new SuperRobot(new List<Locker> { new Locker(2) });

            var bag = new Bag();
            Ticket ticket = superRobot.Store(bag);

            Assert.AreSame(bag, superRobot.Pick(ticket));
        }

        [Test]
        public void show_select_the_highest_vacancy_rate_locker_when_store_bag()
        {
            var locker1 = new Locker(3);
            var locker2 = new Locker(2);
            var superRobot = new SuperRobot(
                new List<Locker>
                    {
                        locker1,
                        locker2
                    });

            locker1.Store(new Bag());

        }
    }
}
