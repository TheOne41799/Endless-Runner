using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRB;
        [SerializeField] private Transform feetPosition;

        private LayerMask groundLayer;
        private float groundDistance;

        private Vector2 playerVelocity;

        public void InitializeView(PlayerData playerData)
        {
            this.groundLayer = playerData.GroundLayer;
            this.groundDistance = playerData.GroundDistance;

            playerRB.gravityScale = playerData.GravityScale;
        }

        public bool CheckIfGrounded()
        {
            return Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);
        }

        public void UpdateVelocity(Vector2 playerVelocity)
        {
            if (playerVelocity == Vector2.zero) return;
            this.playerVelocity = playerVelocity;
        }

        private void FixedUpdate()
        {
            playerRB.linearVelocity = playerVelocity;
        }
    }
}