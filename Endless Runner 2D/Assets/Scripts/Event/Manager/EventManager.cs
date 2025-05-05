using UnityEngine;

namespace EndlessRunner.Event
{
    public class EventManager: IEventManager
    {
        public GameEvents GameEvents { get;}
        public UIEvents UIEvents { get;}

        public EventManager()
        {
            GameEvents = new GameEvents();
            UIEvents = new UIEvents();
        }
    }
}