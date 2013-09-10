using System;
using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    class RobotTest
    {
        private int LOCKER_COUNT = 4;
        List<Locker> lockers;
        List<Locker> oneLocker;

        [SetUp]
        public void Init()
        {
            oneLocker = new List<Locker>();
            lockers = new List<Locker>();
            for (int i = 0; i < LOCKER_COUNT; i++)
            {
                lockers.Add(new Locker(10));
            }

            oneLocker.Add(new Locker(10));
        }

        [Test]
        public void should_get_a_ticket_when_robot_fisrt_store_a_bag_in_locker()
        {
            var robot = new Robot(lockers);
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Test]
        public void should_pick_bag_which_we_stroed_in()
        {
            var robot = new Robot(lockers);
            var bagStore = new Bag();

            Ticket ticket = robot.Store(bagStore);

            var bagPick = robot.Pick(ticket);

            Assert.AreSame(bagPick, bagStore);
        }

        [Test]
        public void should_circle_pick_and_store()
        {
            var robot = new Robot(oneLocker);
            for (int i = 0; i <= oneLocker.Count; i++)
            {
                robot.Store(new Bag());
            }

            var firstBag = new Bag();
            var secondBag = new Bag();

            var firstTicket = robot.Store(firstBag);
            robot.Pick(firstTicket);

            var secondTicket = robot.Store(secondBag);

            Assert.NotNull(secondTicket);
        }
        
        [Test]
        public void should_store_bag_in_sequence()
        {
            var lockersWithOneCapcity = new List<Locker>();
            for (int i = 0; i < LOCKER_COUNT; i++)
            {
                lockersWithOneCapcity.Add(new Locker(1));
            }

            var robot = new Robot(lockersWithOneCapcity);

            lockersWithOneCapcity[0].Store(new Bag());
            lockersWithOneCapcity[2].Store(new Bag());

            robot.Store(new Bag());

            Assert.AreEqual(lockersWithOneCapcity[1].Capacity, 0);
            Assert.AreEqual(lockersWithOneCapcity[3].Capacity, 1);
        }

        [Test]
        public void should_return_null_when_pick_bag_with_incorrect_ticket()
        {
            var robot = new Robot(oneLocker);
            var firstBag = new Bag();
            var ticket = new Ticket();

            robot.Store(firstBag);

            var bag = robot.Pick(ticket);
            
            Assert.Null(bag);
        }
        
        [Test]
        public void should_return_null_when_pick_bag_with_used_ticket()
        {
            var robot = new Robot(oneLocker);
            var firstBag = new Bag();

            var ticket = robot.Store(firstBag);

            robot.Pick(ticket);
            
            Assert.Null(robot.Pick(ticket));
        }
        
        
        [Test]
        public void should_return_error_message_when_lockers_are_full()
        {
            var lockerSize = 10;
            var robot = new Robot(oneLocker);
       
            for (int i = 0; i < lockerSize; i++)
            {
                robot.Store(new Bag());
            }
            var anotherBag = new Bag();


            var ex = Assert.Throws<ArgumentException>(() => robot.Store(anotherBag));
            Assert.That(ex.Message, Is.EqualTo("The lockers are full!"));
            Assert.True(robot.IsFull());
        }

        [Test]
        public void should_return_error_message_when_robot_without_lockers()
        {
            List<Locker> emptyLockers = new List<Locker>();
            var bag1 = new Bag();

            var robot = new Robot(emptyLockers);

            var ex = Assert.Throws<ArgumentException>(() => robot.Store(bag1));
            Assert.That(ex.Message, Is.EqualTo("No locker is available"));
        }

    }
}
