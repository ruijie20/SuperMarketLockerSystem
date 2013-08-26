using System;

namespace SuperMarketLockerSystem
{
    public class Ticket
    {
        private string _ticket;

        public Ticket(string ticket)
        {
            _ticket = ticket;
        }

        public string TicketNum
        {
            get { return _ticket; }
            set {}
        }
    }
}