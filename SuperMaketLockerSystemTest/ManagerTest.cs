using System;
using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    [TestFixture]
    public class ManagerTest
    {
        private List<IBagKeeper> lockerListForManager;
        private List<Locker> lockerListForRobot;
        private Locker locker;
        private Manager manager;
        private Bag bag;
        private Bag bag2;
        private List<IBagKeeper> robotList;
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
            bag2 = new Bag();
            locker = new Locker(1);
        }

        [Test]
        public void should_get_ticket_when_manage_lockers_to_store_bag()
        {
            //Given
            lockerListForManager = new List<IBagKeeper>();


            lockerListForManager.Add(locker);
            manager = new Manager(lockerListForManager);

            //When
            Ticket ticket = manager.Store(bag);

            //Then
            Assert.NotNull(ticket);
            Assert.AreSame(bag, locker.Pick(ticket));
        }

        [Test]
        public void should_pick_bag_with_ticket()
        {
            //Given
            lockerListForManager = new List<IBagKeeper>();

            lockerListForManager.Add(locker);
            manager = new Manager(lockerListForManager);

            //When
            var ticket = manager.Store(bag);
            Bag bagPicked = manager.Pick(ticket);

            //Then
            Assert.AreSame(bag, bagPicked);
        }

        [Test]
        public void should_get_ticket_when_manage_robots_to_store_bag()
        {
            //Given
            lockerListForRobot = new List<Locker>();
            lockerListForRobot.Add(locker);

            robot = new Robot(lockerListForRobot);
            robotList = new List<IBagKeeper>();
            robotList.Add(robot);

            manager = new Manager(robotList);

            //When
            var ticket = manager.Store(bag);

            //Then
            Assert.AreSame(bag, robot.Pick(ticket));
        }

        [Test]
        public void should_get_ticket_when_manage_smart_robots_to_store_bag()
        {
            //Given
            lockerListForRobot = new List<Locker>();
            lockerListForRobot.Add(locker);

            robot = new SmartRobot(lockerListForRobot);
            robotList = new List<IBagKeeper>();
            robotList.Add(robot);

            manager = new Manager(robotList);

            //When
            var ticket = manager.Store(bag);

            //Then
            Assert.AreSame(bag, robot.Pick(ticket));
        }

        [Test]
        public void should_manage_robots_and_lockers_to_store_bag()
        {
            //Given
            var bagKeepers = new List<IBagKeeper>();
            locker = new Locker(1);
            Locker lockerForManager = new Locker(1);
            lockerListForRobot = new List<Locker>();
            lockerListForRobot.Add(locker);
            robot = new Robot(lockerListForRobot);
            bagKeepers.Add(lockerForManager);
            bagKeepers.Add(robot);
            manager = new Manager(bagKeepers);

            //When
            Ticket ticket = manager.Store(bag);
            Ticket ticket2 = manager.Store(bag2);

            //Then
            Assert.NotNull(ticket);
            Assert.NotNull(ticket2);
            Assert.AreSame(bag, manager.Pick(ticket));
            Assert.AreSame(bag2, manager.Pick(ticket2));
        }

        [Test]
        public void should_get_error_message_when_manager_is_full()
        {
            //Given
            var bagKeepers = new List<IBagKeeper>();
            Locker lockerForManager = new Locker(1);
            lockerListForRobot = new List<Locker>();
            lockerListForRobot.Add(new Locker(1));
            var lockerListForSmartRobot = new List<Locker>();
            lockerListForSmartRobot.Add(new Locker(1));
            var lockerListForSuperRobot = new List<Locker>();
            lockerListForSuperRobot.Add(new Locker(1));
            robot = new Robot(lockerListForRobot);
            var smartRobot = new SmartRobot(lockerListForSmartRobot);
            var superRobot = new SuperRobot(lockerListForSuperRobot);

            bagKeepers.Add(smartRobot);
            bagKeepers.Add(superRobot);
            bagKeepers.Add(lockerForManager);
            bagKeepers.Add(robot);
            manager = new Manager(bagKeepers);

            //When
            for (int i = 0; i < 4; i++)
            {
                manager.Store(new Bag());
            }

            //Then
            var ex = Assert.Throws<ArgumentException>(() => manager.Store(new Bag()));
            Assert.That(ex.Message, Is.EqualTo("The manager is full!"));
        }
    }
}