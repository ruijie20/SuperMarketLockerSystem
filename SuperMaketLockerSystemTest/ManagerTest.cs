using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    [TestFixture]
    public class ManagerTest
    {
        private List<Locker> lockerListForLocker;
        private List<Locker> lockerListForRobot;
        private Locker locker;
        private Manager managerForLocker;
        private Manager managerForRobot;
        private Bag bag;
        private List<Robot> robotList; 
        private Robot robot;
        [SetUp]
        public void Setup()
        {
            bag = new Bag();
            
        }

        [Test]
        public void should_get_ticket_when_manage_lockers_to_store_bag()
        {
            //Given
            lockerListForLocker = new List<Locker>();

            locker = new Locker(1);

            lockerListForLocker.Add(locker);
            managerForLocker = new Manager(lockerListForLocker);

            //When
            Ticket ticket = managerForLocker.Store(bag);

            //Then
            Assert.NotNull(ticket);
            Assert.AreSame(bag, locker.Pick(ticket));
        }

        [Test]
        public void should_pick_bag_with_ticket()
        {
            //Given
            lockerListForLocker = new List<Locker>();

            locker = new Locker(1);

            lockerListForLocker.Add(locker);
            managerForLocker = new Manager(lockerListForLocker);

            //When
            var ticket = managerForLocker.Store(bag);
            Bag bagPicked = managerForLocker.Pick(ticket);

            //Then
            Assert.AreSame(bag, bagPicked);
        }

        [Test]
        public void should_get_ticket_when_manage_robots_to_store_bag()
        {
            //Given
            locker = new Locker(1);
            lockerListForRobot = new List<Locker>();
            lockerListForRobot.Add(locker);


            robot = new Robot(lockerListForRobot);
            robotList = new List<Robot>();
            robotList.Add(robot);

            managerForRobot = new Manager(robotList);

            //When
            var ticket = managerForRobot.Store(bag);

            //Then
            Assert.AreSame(bag, robot.Pick(ticket));
        }
    }
}