﻿using System.Collections;
using Controllers;
using Helpers.Player;
using Helpers.AnimationSoundEvents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class JumpInputManager : MonoBehaviour
    {
        [Header("Jump Section"), SerializeField]
        private float jumpForce;
        [SerializeField] private GroundCheck groundCheck;
        [SerializeField] private float fallingMultiplier;
        [SerializeField] private float groundGravScale;
        [SerializeField] private float coyoteTime;
        [SerializeField] private PlayerWalkSFX playerSfx;
        [SerializeField] private AudioClip jumpClip;
        private Rigidbody2D _playerRigidbody;
        private bool _startedFalling;
        private float _coyoteTimer;
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
                _coyoteTimer += Time.deltaTime;

                if (_playerRigidbody.velocity.y < 0)
                {
                    _startedFalling = true;
                    _playerRigidbody.gravityScale = groundGravScale * fallingMultiplier;
                }
            }
            else if (groundCheck.IsGrounded && _startedFalling)
            {
                PlayerController.Instance.PlayerAnimator.SetTrigger(Land);
                PlayerController.Instance.PlayerAnimator.ResetTrigger(Jump);
                _coyoteTimer = 0;
                _startedFalling = false;
                _playerRigidbody.gravityScale = groundGravScale;
            }
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (groundCheck.IsGrounded || _coyoteTimer < coyoteTime)
            {
                PlayerController.Instance.PlayerAnimator.ResetTrigger(Land);
                /*_playerRigidbody.AddForce(
                    Vector2.up * jumpForce,
                    ForceMode2D.Impulse);*/
                _playerRigidbody.gravityScale = groundGravScale;
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, jumpForce);
                PlayerController.Instance.PlayerAnimator.SetTrigger(Jump);
                playerSfx.PlayAudioSource(jumpClip);
            }
        }
    }
}