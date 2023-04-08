using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    public class PlayerInputManager : Singleton<PlayerInputManager>
    {
        [SerializeField] private InputActionAsset inputActions;
        
        [Header("Player Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private Rigidbody2D playerRigidbody;
        private float _targetVelocity;
        
        private InputActionMap _moveInputActionMap;

        protected override void Awake()
        {
            base.Awake();
            _moveInputActionMap = inputActions.FindActionMap("PlayerActions");
        }

        private void OnEnable()
        {
            _moveInputActionMap.Enable();
            _moveInputActionMap.FindAction("MoveHorizontal").performed += OnHorizontalPerformed;
            _moveInputActionMap.FindAction("MoveHorizontal").canceled += OnHorizontalCancelled;
        }
        
        private void OnDisable()
        {
            _moveInputActionMap.FindAction("MoveHorizontal").performed -= OnHorizontalPerformed;
            _moveInputActionMap.FindAction("MoveHorizontal").canceled -= OnHorizontalCancelled;
            _moveInputActionMap.Disable();
        }

        private void OnHorizontalPerformed(InputAction.CallbackContext context)
        {
            _targetVelocity = context.ReadValue<float>() * moveSpeed;
        }

        private void OnHorizontalCancelled(InputAction.CallbackContext context)
        {
            _targetVelocity = 0;
        }

        private void FixedUpdate()
        {
            var currentVelocity = playerRigidbody.velocity.x;
            var desiredVelocity = Mathf.MoveTowards(currentVelocity, _targetVelocity, acceleration * Time.deltaTime);
            playerRigidbody.velocity = new Vector2(desiredVelocity, playerRigidbody.velocity.y);
        }
    }
}