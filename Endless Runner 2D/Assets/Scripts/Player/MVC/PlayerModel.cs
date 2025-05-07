using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerModel
    {
        #region Values to be fetched from Player Data
        private PlayerData playerData;
        private float jumpForce;
        private float jumpTime;
        #endregion

        #region Other variables
        private bool isGrounded = false;
        private bool isJumping = false;
        private float jumpTimer;

        private Vector2 playerVelocity;
        #endregion

        public PlayerModel(PlayerData playerData)
        {
            this.playerData = playerData;
        }

        public void InitializeModel()
        {
            this.jumpForce = playerData.JumpForce;
            this.jumpTime = playerData.JumpTime;
        }

        public void SetIsGrounded(bool isGrounded)
        {
            this.isGrounded = isGrounded;
        }

        public void HandleInput(float deltaTime)
        {
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpTimer = 0f;
                playerVelocity = Vector2.up * jumpForce;
            }

            if (isJumping && Input.GetKey(KeyCode.Space))
            {
                if (jumpTimer < jumpTime)
                {
                    playerVelocity = Vector2.up * jumpForce;
                    jumpTimer += deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }

            if (!isJumping)
            {
                playerVelocity = Vector2.zero;
            }
        }


        public Vector2 GetPlayerVelocity()
        {
            return playerVelocity;
        }
    }
}