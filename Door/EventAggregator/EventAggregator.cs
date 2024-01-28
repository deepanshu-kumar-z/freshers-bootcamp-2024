using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class EventAggregator
    {
        private static EventAggregator instance;
        private readonly System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.List<System.Action<object>>> subscribers;

        private EventAggregator()
        {
            subscribers = new System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.List<System.Action<object>>>();
        }

        public static EventAggregator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventAggregator();
                }
                return instance;
            }
        }

        public void Subscribe<TEvent>(System.Action<TEvent> subscriber)
        {
            System.Type eventType = typeof(TEvent);

            if (!subscribers.ContainsKey(eventType))
            {
                subscribers[eventType] = new System.Collections.Generic.List<System.Action<object>>();
            }

            subscribers[eventType].Add(obj => subscriber((TEvent)obj));
        }

        public void Publish<TEvent>(TEvent eventObject)
        {
            System.Type eventType = typeof(TEvent);

            if (subscribers.ContainsKey(eventType))
            {
                foreach (var subscriber in subscribers[eventType])
                {
                    subscriber.Invoke(eventObject);
                }
            }
        }
    }
}
