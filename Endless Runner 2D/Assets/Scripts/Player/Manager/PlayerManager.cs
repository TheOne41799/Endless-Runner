using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerManager : MonoBehaviour, IManager
    {
        [SerializeField] private PlayerData playerData;

        private IEventManager eventManager;
        private GameState currentGameState;

        private PlayerController playerController;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager) => this.eventManager = eventManager;

        private void CreatePlayerController()
        {
            playerController = new PlayerController(playerData, this);
            playerController.InitializeController();
        }

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
            eventManager.ObstacleEvents.OnObstacleAvoided.AddListener(OnObstacleAvoided);
        }

        private void OnGameStateUpdated(GameState currentGameState)
        {
            this.currentGameState = currentGameState;

            switch (currentGameState)
            {
                case GameState.MAIN_MENU:
                    break;
                case GameState.IN_GAME:
                    //test - this is not the correct way to do it
                    //because the game state can also be INGAME when going from pause menu
                    if(playerController == null) CreatePlayerController();
                    break;
                case GameState.GAME_OVER:
                    Debug.Log("Game Over");
                    break;
            }
        }

        private void Update()
        {
            if(currentGameState == GameState.IN_GAME) playerController?.OnUpdate(Time.deltaTime);
        }

        private void OnObstacleAvoided(int scoreValue) => playerController.OnObstacleAvoided(scoreValue);
        public void OnScoreUpdated(int playerScore) => eventManager.PlayerEvents.OnScoreUpdated.Invoke(playerScore);
        public void OnHitByObstacle() => eventManager.PlayerEvents.OnHitByObstacle.Invoke();
    }
}