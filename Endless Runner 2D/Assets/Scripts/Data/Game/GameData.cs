using EndlessRunner.Game;
using EndlessRunner.Inputs;
using EndlessRunner.Obstacle;
using EndlessRunner.Player;
using EndlessRunner.UI;
using UnityEngine;

namespace EndlessRunner.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private GameManager gameManagerPrefab;
        [SerializeField] private InputManager inputManagerPrefab;
        [SerializeField] private UIManager uiManagerPrefab;
        [SerializeField] private PlayerManager playerManagerPrefab;
        [SerializeField] private ObstacleManager obstacleManagerPrefab;

        public GameManager GameManagerPrefab => gameManagerPrefab;
        public InputManager InputManagerPrefab => inputManagerPrefab;
        public UIManager UIManagerPrefab => uiManagerPrefab;
        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
        public ObstacleManager ObstacleManagerPrefab => obstacleManagerPrefab;
    }
}