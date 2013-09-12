namespace SuperMarketLockerSystem
{
    public interface IBagKeeper
    {
        Ticket Store(Bag bag);
        Bag Pick(Ticket ticket);
        int Capacity { get;  }
        double VacancyRate { get; }
        bool IsFull();
    }
}