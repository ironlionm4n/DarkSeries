using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackInputManager : Singleton<AttackInputManager>
{
    [SerializeField] private InputActionAsset playerActionAsset;
    [SerializeField] private float attackCooldown;

    private float _cooldownTime;
    private InputAction _attackOneInputAction;
    private static readonly int AttackOne = Animator.StringToHash("AttackOne");
    private void Awake()
    {
        _attackOneInputAction = playerActionAsset.FindAction("AttackOne");
        _attackOneInputAction.Enable();
    }

    private void OnEnable()
    {
        _attackOneInputAction.performed += OnAttackOnePerformed;
        _cooldownTime = 3f;
    }

    private void OnDisable()
    {
        _attackOneInputAction.performed -= OnAttackOnePerformed;
    }

    private void OnAttackOnePerformed(InputAction.CallbackContext context)
    {
        if (!PlayerController.Instance.PlayerAnimator.GetBool(AttackOne) && _cooldownTime > attackCooldown)
        {
            PlayerController.Instance.PlayerAnimator.SetBool(AttackOne, true);
            _cooldownTime = 0;
        }
    }

    private void Update()
    {
        _cooldownTime += Time.deltaTime;
    }

    public void SetAttackOneFalse()
    {
        PlayerController.Instance.PlayerAnimator.SetBool(AttackOne, false);
    }
}