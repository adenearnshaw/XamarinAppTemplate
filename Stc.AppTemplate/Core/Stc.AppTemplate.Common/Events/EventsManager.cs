using System;
using Prism.Events;

namespace Stc.AppTemplate.Common.Events
{
    public class EventsManager : IEventsManager
    {
        private readonly IEventAggregator _eventsAggregator;

        public EventsManager()
        {
            _eventsAggregator = new EventAggregator();
        }

        public IDisposable Subscribe<TEventType>(Action<TEventType> handler,
            ThreadContext context = ThreadContext.PublisherThread)
        {
            try
            {
                var evnt = _eventsAggregator.GetEvent<PubSubEventWrapper<TEventType>>() as PubSubEvent<TEventType>;
                var threadOption = (ThreadOption)context;
                return evnt.Subscribe(handler, threadOption);
            }
            catch
            {
                //Ignore
            }

            return null;
        }

        public void Unsubscribe<TEventType>(Action<TEventType> handler)
        {
            try
            {
                var evnt = _eventsAggregator.GetEvent<PubSubEventWrapper<TEventType>>() as PubSubEvent<TEventType>;
                evnt.Unsubscribe(handler);
            }
            catch (Exception)
            {
                //Ignore
            }
        }

        public void Publish<TEventType>(TEventType payload)
        {
            var evnt = _eventsAggregator.GetEvent<PubSubEventWrapper<TEventType>>() as PubSubEvent<TEventType>;
            evnt.Publish(payload);
        }
    }

    public class PubSubEventWrapper<TEventType> : PubSubEvent<TEventType>
    { }
}