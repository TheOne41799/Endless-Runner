using TMPro;
using UnityEngine;

namespace EndlessRunner.UI
{
    public class UIHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void UpdateScore(int score) => scoreText.text = score.ToString();
    }
}