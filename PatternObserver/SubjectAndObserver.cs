using System.Collections.Generic;
using System.Diagnostics;

namespace PatternObserver
{
    public interface IObserver
    {
        void UpdateState();
    }

    public abstract class Subject
    {
        List<IObserver> _observers;

        public Subject() {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer) {
            Debug.Assert(observer != null, "IObserver параметр равен null",
               "Нельзя получать объекты с значением null");
            _observers.Add(observer);
        }

        public void Dettach(IObserver observer) {
            Debug.Assert(observer != null, "IObserver параметр равен null",
               "Нельзя получать объекты с значением null");
            _observers.Remove(observer);
        }

        protected void Notify() {
            foreach (IObserver observer in _observers) {
                observer.UpdateState();
            }
        }
    }
}
