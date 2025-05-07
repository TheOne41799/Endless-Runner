using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using EndlessRunner.UI;
using UnityEngine;

namespace EndlessRunner.Inputs
{
    public class InputManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        private GameInputActionsAsset gameInputActionsAsset;
        private PlayerInputController playerInputController;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            InitializeInputActionsAsset();
            CreateControllers();
            RegisterEventListeners();
        }
        private void SetManagerDependencies(IEventManager eventManager) => this.eventManager = eventManager;

        private void InitializeInputActionsAsset() => gameInputActionsAsset = new GameInputActionsAsset();

        private void CreateControllers()
        {
            playerInputController = new PlayerInputController(this, gameInputActionsAsset);
        }

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
        }

        private void OnGameStateUpdated(GameState currentGameState)
        {
            switch (currentGameState)
            {
                case GameState.IN_GAME:
                    playerInputController.Enable();
                    break;
                default:
                    playerInputController.Disable();
                    break;
            }
        }
    }
}