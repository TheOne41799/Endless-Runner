using EndlessRunner.Player;
using UnityEngine;

namespace EndlessRunner.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Player Data", fileName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private PlayerView playerViewPrefab;
        [SerializeField] private Vector3 spawnPosition;

        public PlayerView PlayerViewPrefab => playerViewPrefab;
        public Vector3 SpawnPosition => spawnPosition;
    }
}