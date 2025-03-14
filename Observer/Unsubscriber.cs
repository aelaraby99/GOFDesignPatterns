﻿namespace Observer
{
    public class Unsubscriber: IDisposable
    {
        private readonly List<IObserver<Application>> _observers;
        private readonly IObserver<Application> _observer;
        public Unsubscriber(List<IObserver<Application>> observers,IObserver<Application> observer)
        {
            _observers = observers;
            _observer = observer;
        }
        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}