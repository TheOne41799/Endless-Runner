using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Obstacle
{
    public class ObstacleModel
    {
        private ObstacleData obstacleData;
        private float moveSpeed;

        public ObstacleModel(ObstacleData obstacleData)
        {
            this.obstacleData = obstacleData;
        }

        public void InitializeModel()
        {
            this.moveSpeed = obstacleData.MoveSpeed;
        }

        public void ResetModel()
        {
            this.moveSpeed = 0;
        }

        public Vector2 GetVelocity()
        {
            return Vector2.left * moveSpeed;
        }
    }
}