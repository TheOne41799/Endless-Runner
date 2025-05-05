using EndlessRunner.Common;
using EndlessRunner.Data;
using EndlessRunner.Event;
using EndlessRunner.Game;
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
        }

        private void SetManagerDependencies()
        {
            gameManager.InitializeManager(eventManager);
        }
    }
}










