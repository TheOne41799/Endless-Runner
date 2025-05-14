using EndlessRunner.Common;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.Parallax
{
    public class ParallaxManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        public void InitializeManager(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }
    }
}