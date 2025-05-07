using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.Obstacle
{
    public class ObstacleManager : MonoBehaviour, IManager
    {
        [SerializeField] private ObstacleData obstacleData;

        private IEventManager eventManager;
        private GameState currentGameState;

        private ObstaclePool obstaclePool;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            CreateObstaclePool();
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager) => this.eventManager = eventManager;

        private void CreateObstaclePool() 
        {

        }

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
        }

        private void OnGameStateUpdated(GameState currentGameState)
        {
            this.currentGameState = currentGameState;

            switch (currentGameState)
            {
                case GameState.MAIN_MENU:
                    break;
                case GameState.IN_GAME:
                    break;
            }
        }

        private void Update()
        {
            
        }
    }
}