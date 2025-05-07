using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerController
    {
        private PlayerManager playerManager;
        private PlayerData playerData;
        private PlayerModel playerModel;
        private PlayerView playerView;

        public PlayerController(PlayerData playerData, PlayerManager playerManager)
        {
            this.playerData = playerData;
            this.playerManager = playerManager;
        }

        public void InitializeController()
        {
            playerModel = new PlayerModel(playerData, this);
            playerView = GameObject.Instantiate<PlayerView>(playerData.PlayerViewPrefab, playerData.SpawnPosition, Quaternion.identity);

            playerView.InitializeView(playerData, this);
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

        public void OnObstacleAvoided(int scoreValue) => playerModel.OnObstacleAvoided(scoreValue);
        public void OnScoreUpdated(int playerScore) => playerManager.OnScoreUpdated(playerScore);
        public void OnHitByObstacle() => playerManager.OnHitByObstacle();
        public void OnGameOver()
        {
            playerModel = null;
            GameObject.Destroy(playerView.gameObject);
        }
    }
}