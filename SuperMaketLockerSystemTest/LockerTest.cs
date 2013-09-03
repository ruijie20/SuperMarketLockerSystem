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
        public void Init()
        {
            locker = new Locker(10);
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
        public void should_get_locker_is_full_message_when_locker_is_full()
        {
            var lockerSize = 10;
            for (int i = 0; i < lockerSize; i++)
            {
                locker.Store(new Bag());
            }

            var anotherBag = new Bag();

            var ex = Assert.Throws<ArgumentException>(() => locker.Store(anotherBag));
            Assert.That(ex.Message, Is.EqualTo("The locker is full!"));
        }

        [Test]
        public void should_get_correct_bag_when_pick_bag_with_ticket()
        {
            var ticket = locker.Store(bag);

            var bagPick = locker.Pick(ticket);

            Assert.That(bagPick, Is.SameAs(bag));
        }

        [Test]
        public void should_get_nothing_when_pick_bag_with_not_correct_ticket()
        {
            locker.Store(bag);

            var ticket1 = new Ticket();

            Assert.Null(locker.Pick(ticket1));
        }
        
        [Test]
        public void should_get_nothing_when_pick_bag_with_used_ticket()
        {
            var ticket = locker.Store(bag);
            locker.Pick(ticket);

            Assert.Null(locker.Pick(ticket));
        }

        [Test]
        public void should_circle_store()
        {
            for (int i = 0; i <= locker.Capacity; i++)
            {
                locker.Store(new Bag());
            }
            var firstBag = new Bag();
            var secondBag = new Bag();

            var ticket = locker.Store(firstBag);
            locker.Pick(ticket);
            var secondTicket = locker.Store(secondBag);

            Assert.NotNull(secondTicket);
        }

        [Test]
        public void should_store_multi_bags_into_boxes_of_locker()
        {
            var firstBag = new Bag();
            var secondBag = new Bag();

            var firstTicket = locker.Store(firstBag);
            var secondTicket = locker.Store(secondBag);

            Assert.NotNull(firstTicket);
            Assert.NotNull(secondTicket);
        }
    }
}
