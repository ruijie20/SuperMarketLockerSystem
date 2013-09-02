﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;
using Assert = NUnit.Framework.Assert;

namespace SuperMaketLockerSystemTest
{
    public class SmartRobotTest
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
        public void should_get_a_ticket_when_store_a_bag()
        {
            SmartRobot smartRobot = new SmartRobot(oneLocker);
            Bag bag = new Bag();

            Ticket ticket = smartRobot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Test]
        public void should_pick_the_bag_when_ues_the_valid_ticket()
        {
            SmartRobot smartRobot = new SmartRobot(lockers);
            Bag bag = new Bag();

            Ticket ticket = smartRobot.Store(bag);

            Bag bagPicked = smartRobot.Pick(ticket);

            Assert.AreSame(bag, bagPicked);
        }

        [Test]
        public void should_store_bag_in_the_locker_which_has_largest_number_of_empty_boxes()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            var bag3 = new Bag();
            var bag4 = new Bag();
            lockers[0].Store(bag1);
            lockers[1].Store(bag2);
            lockers[3].Store(bag3);
            var smartRobot = new SmartRobot(lockers);
            var ticket4 = smartRobot.Store(bag4);
            
            Assert.AreNotSame(bag4, lockers[0].Pick(ticket4));
            Assert.AreNotSame(bag4, lockers[1].Pick(ticket4));
            Assert.AreNotSame(bag4, lockers[3].Pick(ticket4));
            Assert.AreSame(bag4, lockers[2].Pick(ticket4));
        }
        
        [Test]
        public void should_return_error_message_when_robot_without_lockers()
        {
            List<Locker> emptyLockers = new List<Locker>();
            var bag1 = new Bag();
            
            var smartRobot = new SmartRobot(emptyLockers);

            var ex = Assert.Throws<ArgumentException>(() => smartRobot.Store(bag1));
            Assert.That(ex.Message, Is.EqualTo("No locker is available"));
        }
    }
}
