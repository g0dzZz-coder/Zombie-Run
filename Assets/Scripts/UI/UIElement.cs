using UnityEngine;

namespace ZombieRun.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _root = null;
        [Range(0f, 2f)]
        [SerializeField] private float _animationDuration = 0.5f;

        protected Transform Root => _root ? _root.transform : transform;
        protected float AnimationDuration => _animationDuration;

        private int _lastTweenId;

        protected abstract void OnEnabled();
        protected abstract void OnDisabled();

        public void Show()
        {
            LeanTween.cancel(_lastTweenId);
            Root.gameObject.SetActive(true);

            if (_root)
            {
                _root.alpha = 0f;
                
                var descr = LeanTween.alphaCanvas(_root, 1f, _animationDuration).setOnComplete(OnEnabled);
                _lastTweenId = descr.id;
            }
        }

        public void Hide()
        {
            LeanTween.cancel(gameObject);

            if (_root == null)
            {
                Disable();
                return;
            }

            var descr = LeanTween.alphaCanvas(_root, 0f, _animationDuration).setOnComplete(Disable);
            _lastTweenId = descr.id;
        }

        protected void Disable()
        {
            OnDisabled();
            Root.gameObject.SetActive(false);
        }
    }
}