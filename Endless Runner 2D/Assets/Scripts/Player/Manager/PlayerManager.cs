using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using System.IO;
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
        private int highScore;

        private string ScoreFilePath => Path.Combine(Application.persistentDataPath, "scoreData.json");

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            LoadHighScoreFromJson();
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
                case GameState.IN_GAME:
                    OnGameStart();
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

        private void OnGameStart()
        {
            if (playerController == null) CreatePlayerController();
            currentScore = 0;
            eventManager.PlayerEvents.OnScoreUpdated.Invoke(currentScore);
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
            UpdateHighscore();
            eventManager.PlayerEvents.OnGameover.Invoke(currentScore, highScore);
        }

        private void UpdateHighscore()
        {
            if (highScore < currentScore)
            {
                highScore = currentScore;
                SaveHighScoreToJson();
            }
        }

        private void SaveHighScoreToJson()
        {
            PlayerScoreData data = new PlayerScoreData { highScore = highScore };
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(ScoreFilePath, json);
        }

        private void LoadHighScoreFromJson()
        {
            if (File.Exists(ScoreFilePath))
            {
                string json = File.ReadAllText(ScoreFilePath);
                PlayerScoreData data = JsonUtility.FromJson<PlayerScoreData>(json);
                highScore = data.highScore;
            }
            else
            {
                highScore = 0;
            }
        }
    }
}