﻿using System;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMaketLockerSystemTest
{
    class RobotTest
    {
        [Test]
        public void should_get_a_ticket_when_robot_fisrt_store_a_bag_in_locker()
        {
            var robot = new Robot(10);
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Test]
        public void should_get_two_different_tickets_when_robot_store_two_bags_in_locker()
        {
            var robot = new Robot(10);
            var firstBag = new Bag();
            var secondBag = new Bag();

            Ticket firstTicket = robot.Store(firstBag);
            Ticket secondTicket = robot.Store(secondBag);

            Assert.NotNull(firstTicket);
            Assert.NotNull(secondTicket);
            Assert.AreNotSame(firstTicket, secondTicket);
        } 

        [Test]
        public void should_pick_bag_which_we_stroed_in()
        {
            var robot = new Robot(10);
            var bagStore = new Bag();

            Ticket ticket = robot.Store(bagStore);

            var bagPick = robot.Pick(ticket);

            Assert.AreSame(bagPick, bagStore);
        }

        [Test]
        public void should_pick_different_bag_with_different_ticket()
        {
            var robot = new Robot(10);
            var firstBag = new Bag();
            var secondBag = new Bag();

            var firstTicket = robot.Store(firstBag);
            var secondTicket = robot.Store(secondBag);

            var firstPickBag = robot.Pick(firstTicket);
            var secondPickBag = robot.Pick(secondTicket);

            Assert.AreSame(firstBag, firstPickBag);
            Assert.AreSame(secondBag, secondPickBag);
        }

        [Test]
        public void should_circle_pick_and_store()
        {
            var robot = new Robot(1);
            var firstBag = new Bag();
            var secondBag = new Bag();

            var firstTicket = robot.Store(firstBag);
            var firstPickBag = robot.Pick(firstTicket);

            var secondTicket = robot.Store(secondBag);

            Assert.NotNull(secondTicket);
            Assert.AreSame(firstBag, firstPickBag);
        }

        [Test]
        public void should_return_null_when_pick_bag_with_incorrect_ticket()
        {
            var robot = new Robot(1);
            var firstBag = new Bag();
            var ticket = new Ticket();

            robot.Store(firstBag);

            var bag = robot.Pick(ticket);
            
            Assert.Null(bag);
        }
        
        [Test]
        public void should_return_error_message_when_lockers_are_full()
        {
            var robot = new Robot(1);
            var firstBag = new Bag();
            var secondBag = new Bag();

            robot.Store(firstBag);

            var ex = Assert.Throws<ArgumentException>(() => robot.Store(secondBag));
            Assert.That(ex.Message, Is.EqualTo("The lockers are full!"));
        }
    }
}