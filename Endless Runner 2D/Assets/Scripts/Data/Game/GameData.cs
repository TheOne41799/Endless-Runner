using EndlessRunner.Game;
using EndlessRunner.UI;
using UnityEngine;

namespace EndlessRunner.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private GameManager gameManagerPrefab;
        [SerializeField] private UIManager uiManagerPrefab;

        public GameManager GameManagerPrefab => gameManagerPrefab;
        public UIManager UIManagerPrefab => uiManagerPrefab;
    }
}