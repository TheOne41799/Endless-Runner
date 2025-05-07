using EndlessRunner.Data;
using UnityEngine;

namespace EndlessRunner.Obstacle
{
    public class ObstacleController
    {
        private ObstacleData obstacleData;
        private Transform parentTransform;
        private ObstacleModel obstacleModel;
        private ObstacleView obstacleView;

        public ObstacleController(ObstacleData obstacleData, Transform parentTransform)
        {
            this.obstacleData = obstacleData;
            this.parentTransform = parentTransform;
        }

        public void CreateModel() => obstacleModel = new ObstacleModel(obstacleData);

        public void CreateView() => obstacleView = GameObject.Instantiate<ObstacleView>(
                                                    obstacleData.ObstacleViewPrefab,
                                                    parentTransform);

        /*public void CreateView() => obstacleView = GameObject.Instantiate<ObstacleView>(
                                                    obstacleData.ObstacleViewPrefab,
                                                    obstacleData.SpawnPositions[Random.Range(0, obstacleData.SpawnPositions.Length)].position,
                                                    Quaternion.identity,
                                                    parentTransform);*/

        public void InitializeController()
        {
            obstacleModel.InitializeModel();
            obstacleView.InitializeView();
            obstacleView.SetController(this);
        }

        public void ResetController()
        {
            obstacleModel.ResetModel();
            obstacleView.ResetView();
        }

        public void Activate(Vector3 spawnPosition)
        {
            obstacleView.transform.position = spawnPosition;
            obstacleView.SetRandomSprite(obstacleData.ObstacleSprites);
            obstacleView.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            obstacleView.gameObject.SetActive(false);
            ObstacleManager manager = parentTransform.GetComponent<ObstacleManager>();
            manager.GetPool().ReleaseObstacle(this);
        }

        public Vector2 GetVelocity() => obstacleModel.GetVelocity();
    }
}