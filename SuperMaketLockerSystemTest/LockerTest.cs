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
    }
}
