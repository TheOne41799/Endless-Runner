using EndlessRunner.Common;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.Game
{
    public class GameManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;
        private GameState currentGameState;

        private void Awake() => Application.targetFrameRate = 60;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            SetGameState(GameState.MAIN_MENU);
        }

        private void SetManagerDependencies(IEventManager eventManager) => this.eventManager = eventManager;

        private void RegisterEventListeners()
        {
            
        }

        private void SetGameState(GameState gameState)
        {
            if (currentGameState == gameState) return;

            currentGameState = gameState;
            UpdateTimeScale();

            eventManager.GameEvents.OnGameStateUpdated.Broadcast(currentGameState);
        }

        private void UpdateTimeScale() => Time.timeScale = currentGameState == GameState.IN_GAME ? 1f : 0f;
    }
}