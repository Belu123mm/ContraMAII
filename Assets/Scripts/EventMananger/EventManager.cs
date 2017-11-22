using System.Collections.Generic;

public class EventManager
{
    public delegate void EventReceiver(params object[] parameContainer);
      private static Dictionary<string, EventReceiver> _events;


      public static void SubscribeToEvent(string eventT, EventReceiver listener)
      {
          if (_events == null)
              _events = new Dictionary<string, EventReceiver>();

          if (!_events.ContainsKey(eventT))
              _events.Add(eventT, null);

          _events[eventT] += listener;
      }

      public static void UnsubscribeToEvent(string eventT, EventReceiver listener)
      {
          if (_events != null)
          {
              if (_events.ContainsKey(eventT))
                  _events[eventT] -= listener;
          }
      }

      public static void TriggerEvent(string eventType)
      {
          TriggerEvent(eventType, null);
      }

      public static void TriggerEvent(string eventT, params object[] paramWrapper)
      {
          if (_events == null)
          {
              UnityEngine.Debug.LogWarning("Nope");
              return;
          }
          if (_events.ContainsKey(eventT))
          {
              if (_events[eventT] != null)
                  _events[eventT](paramWrapper);
          }
      }
  }

