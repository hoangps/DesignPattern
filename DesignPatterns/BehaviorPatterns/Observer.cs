using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    /// <summary>
    /// Observer is used as data change subscription. 
    /// So whenever the value of the subscribed variable is changed, all subscribers will be notified with the new value to update it accordingly.
    /// </summary>
    public class Observer : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("Observer");

            var speedSensor = new SpeedSensor("SpeedSensor", 50);
            var speedAlarm = new SpeedAlarm();
            speedSensor.Subscribe(speedAlarm);

            speedSensor.Value = 90;
            speedSensor.Value = 110;
            speedSensor.Value = 90;

            Console.ReadLine();
        }
    }



    public interface ISubscriber
    {
        void Update(Sensor sensor);
        T GetValue<T>(Sensor sensor);
    }

    public abstract class Sensor
    {
        private string _name;
        private object _value;

        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public string Name { get { return _name; } }

        /// <summary>
        /// The ULTIMATE PURPOSE of the pattern.
        /// When setting with new value, we Notify the subscribers
        /// </summary>
        public object Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;

                _value = value;
                Notify();
            }
        }

        public Sensor(string name, object initialValue)
        {
            _name = name;
            _value = initialValue;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (ISubscriber subscriber in _subscribers)
                subscriber.Update(this);
        }
    }

    public class SpeedAlarm : ISubscriber
    {
        private const int MAXIMUM_SPEED = 100;
        private int _speed = 0;

        public T GetValue<T>(Sensor sensor)
        {
            try
            {
                return (T)sensor.Value;
            }
            catch
            {
                return default(T);
            }
        }

        public void Update(Sensor sensor)
        {
            var newSpeed = GetValue<int>(sensor);

            if (newSpeed > MAXIMUM_SPEED)
                Console.WriteLine("Achtung! You are driving too fast!");
            else if (_speed > MAXIMUM_SPEED)
                Console.WriteLine("Good job! You are back to safe speed.");

            _speed = newSpeed;
        }
    }

    public class SpeedSensor : Sensor
    {
        public SpeedSensor(string name, object initialValue) : base(name, initialValue)
        {
        }
    }
}
