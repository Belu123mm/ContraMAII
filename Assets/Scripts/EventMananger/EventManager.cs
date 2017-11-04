using System.Collections.Generic;

public class EventManager
{
    public delegate void EventReceiver(params object[] parameContainer);
    private static Dictionary<EventType, EventReceiver> _events;

    public static void SubscribeToEvent(EventType eventT, EventReceiver listener)
    {
        if (_events == null)
            _events = new Dictionary<EventType, EventReceiver>();

        if (!_events.ContainsKey(eventT))
            _events.Add(eventT, null);

        _events[eventT] += listener;
    }
    public static void UnsubscribeToEvent(EventType eventT, EventReceiver listener)
    {
        if (_events != null)
        {
            if (_events.ContainsKey(eventT))
                _events[eventT] -= listener;
        }
    }

    public static void TriggerEvent(EventType eventType)
    {
        TriggerEvent(eventType, null);
    }

    public static void TriggerEvent(EventType eventT, params object[] paramWrapper)
    {
        if (_events == null)
        {
            UnityEngine.Debug.LogWarning("No events subscribed");
            return;
        }

        if (_events.ContainsKey(eventT))
        {
            if (_events[eventT] != null)
                _events[eventT](paramWrapper);
        }
    }
}
public enum EventType
{
    Hero_life,
    Hero_death,
    Game_win,
    Game_lose,
    Game_score,
    Game_particles
}
