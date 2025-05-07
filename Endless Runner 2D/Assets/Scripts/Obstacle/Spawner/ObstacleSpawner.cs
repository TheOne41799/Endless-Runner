using System.Collections;
using UnityEngine;

namespace EndlessRunner.Obstacle
{
    public class ObstacleSpawner
    {
        private ObstacleManager obstacleManager;
        private Coroutine spawnRoutine;

        public ObstacleSpawner(ObstacleManager obstacleManager)
        {
            this.obstacleManager = obstacleManager;
        }

        public void StartSpawning()
        {
            spawnRoutine = obstacleManager.StartCoroutine(StartSpawner());
        }

        public void StopSpawning()
        {
            if (spawnRoutine != null)
                obstacleManager.StopCoroutine(spawnRoutine);
        }

        private IEnumerator StartSpawner()
        {
            while (true)
            {
                yield return new WaitForSeconds(obstacleManager.GetData().ObstacleSpawnTime);

                ObstacleController controller = obstacleManager.GetPool().GetObstacle();
                Vector3[] spawnPositions = obstacleManager.GetData().SpawnPositions;
                Vector3 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)];

                controller.Activate(spawnPos);
            }
        }
    }
}