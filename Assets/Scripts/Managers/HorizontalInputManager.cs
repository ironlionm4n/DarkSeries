using System;
using Controllers;
using Helpers.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    public class HorizontalInputManager : MonoBehaviour
    {
        [Header("Player Movement")] [SerializeField]
        private float groundSpeed;

        [SerializeField] private float airSpeed;
        [SerializeField] private float acceleration;
        [SerializeField, Range(0f, 1f)] private float airControlFactor;
        [SerializeField] private GroundCheck groundCheck;

        private Rigidbody2D _playerRigidbody;
        private float _targetVelocity;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
            PlayerController.Instance.HorizontalInputAction.performed += OnHorizontalPerformed;
            PlayerController.Instance.HorizontalInputAction.canceled += OnHorizontalCancelled;
        }

        private void OnDestroy()
        {
            if (PlayerController.Instance != null)
            {
                PlayerController.Instance.HorizontalInputAction.performed -= OnHorizontalPerformed;
                PlayerController.Instance.HorizontalInputAction.canceled -= OnHorizontalCancelled;
            }
        }

        private void OnHorizontalPerformed(InputAction.CallbackContext context)
        {
            var contextValue = context.ReadValue<float>();
            PlayerController.Instance.HandleSpriteFlip(contextValue);
            _targetVelocity = (contextValue * groundSpeed);
        }

        private void OnHorizontalCancelled(InputAction.CallbackContext context)
        {
            _targetVelocity = 0;
        }

        private void Update()
        {
            PlayerController.Instance.PlayerAnimator.SetFloat(Horizontal, Mathf.Abs(_targetVelocity));
        }

        private void FixedUpdate()
        {
            var currentVelocity = _playerRigidbody.velocity.x;
            var desiredVelocity = Mathf.MoveTowards(currentVelocity, groundCheck.IsGrounded ? _targetVelocity : (_targetVelocity * airControlFactor), acceleration * Time.deltaTime);
            _playerRigidbody.velocity = new Vector2(desiredVelocity, _playerRigidbody.velocity.y);
        }
    }
}