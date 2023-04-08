using System;
using System.Collections;
using Controllers;
using Helpers.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class JumpInputManager : MonoBehaviour
    {
        [Header("Jump Section"), SerializeField] private float jumpForce;
        [SerializeField] private GroundCheck groundCheck;
        [SerializeField] private float jumpGravScale;
        [SerializeField] private float groundGravScale;
        [SerializeField] private float gravityDelta;
        private Rigidbody2D _playerRigidbody;

            private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            PlayerController.Instance.JumpInputAction.performed += OnJumpPerformed;
        }

        private void Update()
        {
            if (!groundCheck.IsGrounded)
            {
                _playerRigidbody.gravityScale = Mathf.MoveTowards(_playerRigidbody.gravityScale, jumpGravScale, gravityDelta);
            }
            else
            {
                _playerRigidbody.gravityScale = groundGravScale;
            }
                
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (!groundCheck.IsGrounded) return;

            _playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
}