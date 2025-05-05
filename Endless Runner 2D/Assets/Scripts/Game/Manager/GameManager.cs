using EndlessRunner.Common;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.Game
{
    public class GameManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;
        private GameState currentGameState;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            SetGameState(GameState.MAIN_MENU);
        }

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
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

            // broadcast an event to indicate game state has been update
        }

        private void UpdateTimeScale()
        {
            Time.timeScale = currentGameState == GameState.IN_GAME ? 1f : 0f;

            Debug.Log("Game state has been updated: " + currentGameState);
            Debug.Log("Current time scale is: " + Time.timeScale);
        }
    }
}