using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerController
    {
        private PlayerData playerData;
        private PlayerModel playerModel;
        private PlayerView playerView;

        public PlayerController(PlayerData playerData)
        {
            this.playerData = playerData;
        }

        public void InitializeController()
        {
            playerModel = new PlayerModel(playerData);
            playerView = GameObject.Instantiate<PlayerView>(playerData.PlayerViewPrefab, playerData.SpawnPosition, Quaternion.identity);

            playerView.InitializeView(playerData);
            playerModel.InitializeModel();
        }

        public void OnUpdate(float deltaTime)
        {
            bool isGrounded = playerView.CheckIfGrounded();
            playerModel.SetIsGrounded(isGrounded);

            playerModel.HandleInput(deltaTime);

            if (playerModel.ShouldApplyJump)
            {
                playerView.RequestJump(playerModel.GetJumpForce);
            }
        }
    }
}