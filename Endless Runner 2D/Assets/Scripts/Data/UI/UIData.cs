using EndlessRunner.UI;
using UnityEngine;

namespace EndlessRunner.Data
{
    [CreateAssetMenu(menuName = "Game Data/ UI Data", fileName = "UI Data")]
    public class UIData : ScriptableObject
    {
        [SerializeField] private UIMainMenu uiMainMenuPrefab;

        public UIMainMenu UIMainMenuPrefab => uiMainMenuPrefab;
    }
}