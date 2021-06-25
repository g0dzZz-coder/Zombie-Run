using UnityEngine;

namespace ZombieRun.UI
{
    public class PopupMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _root = null;
        [Range(0f, 2f)]
        [SerializeField] private float _animationDuration = 0.5f;

        protected Transform Root => _root ? _root.transform : transform;

        public void Show()
        {
            Root.gameObject.SetActive(true);

            if (_root)
            {
                _root.alpha = 0f;
                LeanTween.alphaCanvas(_root, 1f, _animationDuration);
            }
        }

        public void Hide()
        {
            if (_root == null)
            {
                Disable();
                return;
            }

            LeanTween.alphaCanvas(_root, 0f, _animationDuration).setOnComplete(Disable);
        }

        protected void Disable()
        {
            Root.gameObject.SetActive(false);
        }
    }
}