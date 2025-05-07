using EndlessRunner.Player;
using UnityEngine;

namespace EndlessRunner.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Player Data", fileName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private PlayerView playerViewPrefab;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private float jumpForce;
        [SerializeField] private float groundDistance;
        [SerializeField] private float jumpTime;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float gravityScale = 5f;

        public PlayerView PlayerViewPrefab => playerViewPrefab;
        public Vector3 SpawnPosition => spawnPosition;
        public float JumpForce => jumpForce;
        public float GroundDistance => groundDistance;
        public float JumpTime => jumpTime;
        public LayerMask GroundLayer => groundLayer;
        public float GravityScale => gravityScale;
    }
}