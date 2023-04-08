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
        [SerializeField] private float fallingMultiplier;
        [SerializeField] private float groundGravScale;
        private Rigidbody2D _playerRigidbody;
        private bool _startedFalling;
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Land = Animator.StringToHash("Land");

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
                if (_playerRigidbody.velocity.y < 0)
                {
                    _playerRigidbody.gravityScale = groundGravScale * fallingMultiplier;
                    _startedFalling = true;
                }
            }
            else if(groundCheck.IsGrounded && _startedFalling)
            {
                PlayerController.Instance.PlayerAnimator.SetTrigger(Land);
                //PlayerController.Instance.PlayerAnimator.ResetTrigger(Land);
                _startedFalling = false;
                _playerRigidbody.gravityScale = groundGravScale;
            }
                
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (!groundCheck.IsGrounded) return;
            
            _playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            PlayerController.Instance.PlayerAnimator.SetTrigger(Jump);
            //PlayerController.Instance.PlayerAnimator.ResetTrigger(Jump);
        }

    }
}