using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using EndlessRunner.Game;
using EndlessRunner.UI;
using UnityEngine;
using UnityEngine.VFX;

namespace EndlessRunner.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

        [SerializeField] private GameData gameData;

        private IEventManager eventManager;

        private IManager gameManager;
        private IManager uiManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            CreateEventManager();
            CreateManagers();
            SetManagerDependencies();
        }

        private void CreateEventManager()
        {
            eventManager = new EventManager();
        }

        private void CreateManagers()
        {
            gameManager = GameObject.Instantiate<GameManager>(gameData.GameManagerPrefab, this.transform);
            uiManager = GameObject.Instantiate<UIManager>(gameData.UIManagerPrefab, this.transform);
        }

        private void SetManagerDependencies()
        {
            gameManager.InitializeManager(eventManager);
            uiManager.InitializeManager(eventManager);
        }
    }
}










