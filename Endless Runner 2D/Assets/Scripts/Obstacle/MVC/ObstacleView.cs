using UnityEngine;

namespace EndlessRunner.Obstacle
{
    public class ObstacleView : MonoBehaviour
    {
        private ObstacleController controller;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void SetController(ObstacleController controller)
        {
            this.controller = controller;
        }

        public void InitializeView()
        {
            this.gameObject.SetActive(true);
        }

        public void ResetView()
        {
            this.gameObject.SetActive(false);
        }

        public void SetRandomSprite(Sprite[] sprites)
        {
            if (sprites.Length > 0)
                spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }

        private void Update()
        {
            if (controller != null)
            {
                transform.Translate(controller.GetVelocity() * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("asads");
            if (collision.CompareTag("Despawn"))
            {
                controller.Deactivate();
                Debug.Log("asads");
            }
        }
    }
}