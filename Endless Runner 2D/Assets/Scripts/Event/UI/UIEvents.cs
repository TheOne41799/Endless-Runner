using UnityEngine;
using System;

namespace EndlessRunner.Event
{
    public class UIEvents
    {
        public IEventController<Action> OnStartButtonClicked { get; }

        public UIEvents()
        {
            OnStartButtonClicked = new DeferredEventController<Action>();
        }
    }
}