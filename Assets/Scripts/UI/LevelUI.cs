using TMPro;
using UnityEngine;

namespace ZombieRun.UI
{
    using Levels;

    [RequireComponent(typeof(CanvasGroup))]
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText = null;
        [SerializeField] private float _animationDuration = 0.5f;

        private CanvasGroup _canvasGroup = null;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            OnLevelUpdated(LevelSystem.Instance.GetLastPlayedLevel());
        }

        public void OnLevelUpdated(LevelData data)
        {
            if (data == null)
            {
                _canvasGroup.alpha = 0f;
                return;
            }

            titleText.text = data.id;
            LeanTween.alphaCanvas(_canvasGroup, 1f, _animationDuration);
        }
    }
}