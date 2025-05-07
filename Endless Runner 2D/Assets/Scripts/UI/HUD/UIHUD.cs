using TMPro;
using UnityEngine;

namespace EndlessRunner.UI
{
    public class UIHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void ShowUI() => this.gameObject.SetActive(true);
        public void HideUI() => this.gameObject.SetActive(false);
        public void OnScoreUpdated(int playerScore) => scoreText.text = playerScore.ToString();
    }
}