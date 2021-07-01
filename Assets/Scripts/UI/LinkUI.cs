using UnityEngine;
using UnityEngine.EventSystems;

namespace ZombieRun.UI
{
    public class LinkUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private string _url = string.Empty;

        public void OnPointerClick(PointerEventData eventData)
        {
            OpenUrl();
        }

        private void OpenUrl()
        {
            if (string.IsNullOrWhiteSpace(_url))
                return;

            Application.OpenURL(_url);
        }
    }
}