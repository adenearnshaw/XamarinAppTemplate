using System;

namespace $safeprojectname$.Events
{
    public interface IEventsManager
    {
        IDisposable Subscribe<TEventType>(Action<TEventType> handler,
            ThreadContext context = ThreadContext.PublisherThread);

        void Unsubscribe<TEventType>(Action<TEventType> handler);

        void Publish<TEventType>(TEventType payload);
    }

    public enum ThreadContext
    {
        PublisherThread,
        UIThread,
        BackgroundThread
    }
}