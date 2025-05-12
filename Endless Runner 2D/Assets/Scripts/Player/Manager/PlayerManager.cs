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

        private int currentScore;
        private int highScore = 500;

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
                    if(playerController == null) CreatePlayerController();
                    eventManager.PlayerEvents.OnScoreUpdated.Invoke(currentScore);
                    break;
                case GameState.GAME_OVER:
                    OnGameOver();
                    break;
            }
        }

        private void Update()
        {
            if(currentGameState == GameState.IN_GAME) playerController?.OnUpdate(Time.deltaTime);
        }

        private void OnObstacleAvoided(int scoreValue) => playerController.OnObstacleAvoided(scoreValue);
        public void OnScoreUpdated(int playerScore)
        {
            currentScore = playerScore;
            eventManager.PlayerEvents.OnScoreUpdated.Invoke(playerScore);
        }

        public void OnHitByObstacle() => eventManager.PlayerEvents.OnHitByObstacle.Invoke();
        public void OnGameOver()
        {
            playerController?.OnGameOver();
            playerController = null;
            ResetScoreVariables();
        }

        private void ResetScoreVariables()
        {
            eventManager.PlayerEvents.OnGameover.Invoke(currentScore, highScore);
            currentScore = 0;
        }
    }
}