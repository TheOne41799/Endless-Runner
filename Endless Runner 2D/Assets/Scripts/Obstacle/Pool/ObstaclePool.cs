using EndlessRunner.Data;
using UnityEngine;
using UnityEngine.Pool;

namespace EndlessRunner.Obstacle
{
    public class ObstaclePool
    {
        private ObstacleData obstacleData;
        private Transform parentTransform;

        private ObjectPool<ObstacleController> obstacleControllers;

        public ObstaclePool(ObstacleData obstacleData, Transform parentTransform)
        {
            this.obstacleData = obstacleData;
            this.parentTransform = parentTransform;
        }

        public void InitializePool()
        {
            obstacleControllers = new ObjectPool<ObstacleController>(CreateController,
                                                                     OnGetController,
                                                                     OnReleaseController,
                                                                     OnDestroyController);
        }

        private ObstacleController CreateController()
        {
            ObstacleController obstacleController = new ObstacleController(obstacleData, parentTransform);
            obstacleController.CreateModel();
            obstacleController.CreateView();
            return obstacleController;
        }

        private void OnGetController(ObstacleController obstacleController)
        {
            obstacleController.InitializeController();
        }

        private void OnReleaseController(ObstacleController obstacleController)
        {
            obstacleController.ResetController();
        }

        private void OnDestroyController(ObstacleController obstacleController)
        {
            // later
        }

        public ObstacleController GetObstacle() => obstacleControllers.Get();
        public void ReleaseObstacle(ObstacleController controller) => obstacleControllers.Release(controller);
    }
}







