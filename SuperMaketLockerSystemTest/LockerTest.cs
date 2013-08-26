using System;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    [TestFixture]
    public class LockerTest
    {
        private Locker locker;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            locker = new Locker();
            bag = new Bag();

        }
        
        [Test]
        public void should_get_ticket_when_store_null()
        {
            Ticket ticket = locker.Store(null);

            Assert.NotNull(ticket);
        }
        
        [Test]
        public void should_get_ticket_when_store_a_bag()
        {
            Ticket ticket = locker.Store(bag);

            Assert.NotNull(ticket);
        }

        [Test]
        public void should_get_nothing_when_locker_is_full()
        {
            var anotherBag = new Bag();
            var ticket = locker.Store(bag);

            var ex = Assert.Throws<ArgumentException>(() => locker.Store(anotherBag));
            Assert.That(ex.Message, Is.EqualTo("The locker is full!"));
        }

        [Test]
        public void should_get_crrect_bag_when_pick_bag_with_ticket()
        {
            var ticket = locker.Store(bag);

            bag = locker.Pick(ticket);

            Assert.IsFalse(locker.bags.ContainsKey(ticket));
            Assert.That(bag, Is.EqualTo(bag));
        }

        [Test]
        public void should_get_nothing_when_pick_bag_with_invalid_ticket()
        {
            var ticket = locker.Store(bag);

            var ticket1 = new Ticket("ticket1");

            Assert.Null(locker.Pick(ticket1));
        }
    }
}
