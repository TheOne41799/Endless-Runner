using System;
using UnityEngine;

namespace EndlessRunner.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<int>> OnScoreUpdated { get; }
        public IEventController<Action> OnHitByObstacle { get; }

        public PlayerEvents()
        {
            OnScoreUpdated = new DeferredEventController<Action<int>>();
            OnHitByObstacle = new DeferredEventController<Action>();
        }
    }
}