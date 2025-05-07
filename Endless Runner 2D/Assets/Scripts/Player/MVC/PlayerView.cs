using EndlessRunner.Common;
using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerView : MonoBehaviour, IPlayer
    {
        [SerializeField] private Rigidbody2D playerRB;
        [SerializeField] private Transform feetPosition;

        private PlayerController playerController;
        private LayerMask groundLayer;
        private float groundDistance;

        private bool jumpRequested = false;
        private float jumpForce;

        public void InitializeView(PlayerData playerData, PlayerController playerController)
        {
            this.playerController = playerController;
            this.groundLayer = playerData.GroundLayer;
            this.groundDistance = playerData.GroundDistance;
            playerRB.gravityScale = playerData.GravityScale;
        }

        public bool CheckIfGrounded()
        {
            return Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);
        }

        public void RequestJump(float jumpForce)
        {
            jumpRequested = true;
            this.jumpForce = jumpForce;
        }

        private void FixedUpdate()
        {
            if (jumpRequested)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
                jumpRequested = false;
            }
        }

        public void OnHitByObstacle() => playerController.OnHitByObstacle();
    }
}