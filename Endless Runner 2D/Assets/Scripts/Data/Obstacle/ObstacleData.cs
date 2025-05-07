using EndlessRunner.Obstacle;
using UnityEngine;

namespace EndlessRunner.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Obstacle Data", fileName = "Obstacle Data")]
    public class ObstacleData : ScriptableObject
    {
        [SerializeField] private ObstacleView obstacleViewPrefab;

        public ObstacleView ObstacleViewPrefab => obstacleViewPrefab;
    }
}