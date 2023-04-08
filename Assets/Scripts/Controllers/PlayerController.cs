using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class PlayerController : Singleton<PlayerController>
    {
        [SerializeField] private InputActionAsset playerActions;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        public Animator PlayerAnimator => playerAnimator;

        public InputAction HorizontalInputAction { get; private set; }
        public InputAction JumpInputAction { get; private set; }

        private InputAction _jumpAction;

        protected override void Awake()
        {
            base.Awake();
            HorizontalInputAction = playerActions.FindAction("MoveHorizontal");
            JumpInputAction = playerActions.FindAction("Jump");
        }

        public void HandleSpriteFlip(float inputValue)
        {
            if (inputValue < 0)
            {
                playerSpriteRenderer.flipX = true;
            }
            else if (inputValue > 0)
            {
                playerSpriteRenderer.flipX = false;
            }

        }

        private void OnEnable()
        {
            HorizontalInputAction.Enable();
            JumpInputAction.Enable();
        }

        private void OnDisable()
        {
            HorizontalInputAction.Disable();
            JumpInputAction.Disable();
        }
    }
}