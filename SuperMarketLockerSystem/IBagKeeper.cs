namespace SuperMarketLockerSystem
{
    public interface IBagKeeper
    {
        bool IsFull();
        Ticket Store(Bag bag);
        Bag Pick(Ticket ticket);
    }
}