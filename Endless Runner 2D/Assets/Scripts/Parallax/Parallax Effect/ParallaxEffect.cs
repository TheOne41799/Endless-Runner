using UnityEngine;

namespace EndlessRunner.Parallax
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float offset;

        private Vector2 startPosition;
        private float newXPosition;

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            newXPosition = Mathf.Repeat(Time.time * -moveSpeed, offset);
            transform.position = startPosition + Vector2.right * newXPosition;
        }

        public void StartParallax() { }
        public void StopParallax() { }
    }
}