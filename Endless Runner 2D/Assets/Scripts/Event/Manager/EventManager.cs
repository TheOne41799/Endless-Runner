using UnityEngine;

namespace EndlessRunner.Event
{
    public class EventManager: IEventManager
    {
        public GameEvents GameEvents { get;}

        public EventManager()
        {
            GameEvents = new GameEvents();
        }
    }
}