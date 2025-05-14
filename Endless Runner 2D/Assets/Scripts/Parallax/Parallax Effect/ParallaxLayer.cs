using UnityEngine;

namespace EndlessRunner.Parallax
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public ParallaxEffect parallaxLayerPrefab;
        public float moveSpeed;
        public float offset;
    }
}