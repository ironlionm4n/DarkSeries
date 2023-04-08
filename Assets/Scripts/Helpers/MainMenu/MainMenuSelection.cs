using UnityEngine;

namespace Helpers.MainMenu
{
    public class MainMenuSelection : MonoBehaviour
    {
        [SerializeField] private MenuOptions[] menuOptions;
        
        private int _currentSelection = 0;
        private int _totalMenuOptions = 2;

        public void MoveOptionUp()
        {
            _currentSelection = (_currentSelection - 1 + _totalMenuOptions) % _totalMenuOptions;
            UpdateMenuSelection();
        }

        public void MoveOptionDown()
        {
            _currentSelection = (_currentSelection + 1 + _totalMenuOptions) % _totalMenuOptions;
            UpdateMenuSelection();
        }
        
        private void UpdateMenuSelection()
        {
            for (var i = 0; i < _totalMenuOptions; i++)
            {
                if (i == _currentSelection)
                {
                    menuOptions[i].HandleOptionSelected();
                }
                else
                {
                    menuOptions[i].EnsureUnselectedInactive();
                }
            }
        }

        public void HandleSelectionConfirm()
        {
            menuOptions[_currentSelection].HandleButtonClick();
        }
    }
}