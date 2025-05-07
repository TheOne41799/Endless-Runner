using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerModel
    {
        private PlayerController playerController;
        private PlayerData playerData;
        private float jumpForce;
        private float jumpTime;

        private bool isGrounded;
        private bool isJumping;
        private float jumpTimer;

        private bool applyJump;
        private int playerScore;

        public PlayerModel(PlayerData playerData, PlayerController playerController)
        {
            this.playerData = playerData;
            this.playerController = playerController;
        }

        public void InitializeModel()
        {
            this.jumpForce = playerData.JumpForce;
            this.jumpTime = playerData.JumpTime;
            playerScore = 0;
        }

        public void SetIsGrounded(bool isGrounded)
        {
            this.isGrounded = isGrounded;

            if (isGrounded)
            {
                isJumping = false;
                jumpTimer = 0f;
            }
        }

        public void HandleInput(float deltaTime)
        {
            applyJump = false;

            if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                isJumping = true;
                jumpTimer = 0f;
                applyJump = true;
            }
            else if (isJumping && Input.GetKey(KeyCode.UpArrow))
            {
                if (jumpTimer < jumpTime)
                {
                    applyJump = true;
                    jumpTimer += deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                isJumping = false;
            }
        }

        public bool ShouldApplyJump => applyJump;
        public float GetJumpForce => jumpForce;

        public void OnObstacleAvoided(int scoreValue)
        {
            playerScore += scoreValue;
            playerController.OnScoreUpdated(playerScore);
        }
    }
}