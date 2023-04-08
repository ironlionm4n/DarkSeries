using UnityEngine;
using UnityEngine.UI;

namespace Helpers.MainMenu
{
    public class MenuOptions : MonoBehaviour
    {
        [SerializeField] private GameObject selected;
        [SerializeField] private GameObject unselected;

        public void HandleOptionSelected()
        {
            selected.gameObject.SetActive(true);
            unselected.gameObject.SetActive(false);
        }

        public void EnsureUnselectedInactive()
        {
            selected.gameObject.SetActive(false);
            unselected.gameObject.SetActive(true);
        }

        public void HandleButtonClick()
        {
            var button = selected.GetComponentInChildren<Button>();

            if (button != null)
            {
                button.onClick.Invoke();
            }
        }
    }
}