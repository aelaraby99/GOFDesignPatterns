namespace Observer
{
    public interface IPublisher<T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }
}