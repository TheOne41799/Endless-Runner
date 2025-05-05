using EndlessRunner.Common;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.UI
{
    public class UIManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager) => this.eventManager = eventManager;

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
        }

        private void OnGameStateUpdated(GameState currentGameState)
        {
            
        }
    }
}