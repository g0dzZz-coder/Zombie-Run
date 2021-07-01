using TMPro;
using UnityEngine;

namespace ZombieRun.UI
{
    using Levels;

    [RequireComponent(typeof(CanvasGroup))]
    public class LevelPreviewUI : MonoBehaviour
    {
        [SerializeField] private LevelGroup _levelGroup = null;
        [SerializeField] private TMP_Text _levelNameText = null;
        [SerializeField] private float _animationDuration = 0.5f;

        private CanvasGroup _canvasGroup = null;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            OnLevelUpdated(_levelGroup.GetNextLevel());
        }

        public void OnLevelUpdated(LevelData data)
        {
            if (data)
            {
                _levelNameText.text = data.Name;
                LeanTween.alphaCanvas(_canvasGroup, 1f, _animationDuration);

                return;
            }

            _canvasGroup.alpha = 0f;
        }
    }
}