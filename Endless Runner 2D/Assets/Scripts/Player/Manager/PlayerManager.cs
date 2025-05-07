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
            playerController = new PlayerController(playerData);
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
                    //test - this is not the correct way to do it
                    //because the game state can also be INGAME when going from pause menu
                    if(playerController == null) CreatePlayerController();
                    break;
            }
        }

        private void Update()
        {
            if(currentGameState == GameState.IN_GAME) playerController?.OnUpdate(Time.deltaTime);
        }
    }
}