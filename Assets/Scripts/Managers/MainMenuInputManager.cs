using System;
using Helpers.MainMenu;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class MainMenuInputManager : Singleton<MainMenuInputManager>
    {
        [SerializeField] private MainMenuSelection mainMenuSelection;
        [SerializeField] private InputActionAsset inputActions;

        private InputActionMap _mainMenuActionMap;

        protected override void Awake()
        {
            base.Awake();
            _mainMenuActionMap = inputActions.FindActionMap("MainMenu");
        }

        private void OnEnable()
        {
            if (_mainMenuActionMap != null)
            {
                _mainMenuActionMap.Enable();
                _mainMenuActionMap.FindAction("MoveSelection").performed += OnMoveSelection;
                _mainMenuActionMap.FindAction("ConfirmSelection").performed += OnConfirmSelection;
            }
        }

        private void OnDisable()
        {
            if (_mainMenuActionMap != null)
            {
                _mainMenuActionMap.Disable();
                _mainMenuActionMap.FindAction("MoveSelection").performed -= OnMoveSelection;
                _mainMenuActionMap.FindAction("ConfirmSelection").performed -= OnConfirmSelection;
            }
        }

        private void OnMoveSelection(InputAction.CallbackContext context)
        {
            Debug.Log("Hello");
            if (!context.performed)
            {
                return;
            }

            var selectionDirection = context.ReadValue<Vector2>();

            if (selectionDirection.y > 0)
            {
                mainMenuSelection.MoveOptionUp();
            }
            else if (selectionDirection.y < 0)
            {
                mainMenuSelection.MoveOptionDown();
            }
        }

        private void OnConfirmSelection(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            if (context.ReadValue<float>() > 0f)
            {
                mainMenuSelection.HandleSelectionConfirm();
            }
        }
    }
}