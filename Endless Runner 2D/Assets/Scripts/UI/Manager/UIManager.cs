using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using UnityEngine;

namespace EndlessRunner.UI
{
    public class UIManager : MonoBehaviour, IManager
    {
        [SerializeField] private UIData uiData;
        [SerializeField] private Canvas uiCanvas;

        private IEventManager eventManager;

        private UIMainMenuController uiMainMenuController;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            CreateControllers();
            InitializeControllers();
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager) => this.eventManager = eventManager;              

        private void CreateControllers()
        {
            uiMainMenuController = new UIMainMenuController(uiData, uiCanvas, this);
        }

        private void InitializeControllers()
        {
            uiMainMenuController.InitializeController();
        }

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
            eventManager.PlayerEvents.OnScoreUpdated.AddListener(OnScoreUpdated);
        }

        private void OnGameStateUpdated(GameState currentGameState)
        {
            HideAllUIs();

            switch (currentGameState)
            {
                case GameState.MAIN_MENU:
                    uiMainMenuController.ShowUI();
                    break;
                case GameState.IN_GAME:
                    break;
            }
        }

        private void HideAllUIs()
        {
            uiMainMenuController.HideUI();
        }

        public void OnStartButtonClicked() => eventManager.UIEvents.OnStartButtonClicked.Invoke();

        public void OnScoreUpdated(int playerScore) => Debug.Log("Player Score: " + playerScore);
    }
}















