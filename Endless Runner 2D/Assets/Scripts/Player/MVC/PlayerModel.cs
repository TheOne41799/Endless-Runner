using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerModel
    {
        private PlayerData playerData;
        private float jumpForce;
        private float jumpTime;

        private bool isGrounded;
        private bool isJumping;
        private float jumpTimer;

        private bool applyJump; // tells view to apply velocity

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

            // Reset jump when landed
            if (isGrounded)
            {
                isJumping = false;
                jumpTimer = 0f;
            }
        }

        public void HandleInput(float deltaTime)
        {
            applyJump = false;

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpTimer = 0f;
                applyJump = true;
            }
            else if (isJumping && Input.GetKey(KeyCode.Space))
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

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }

        public bool ShouldApplyJump => applyJump;
        public float GetJumpForce => jumpForce;
    }

}