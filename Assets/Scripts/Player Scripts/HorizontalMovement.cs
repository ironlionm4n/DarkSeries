using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stoppingDrag;
    
    private Vector2 _desiredVelocity;
    private Animator _playerAnimator;
    private Rigidbody2D _rigidbody;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    /*private void Update()
    {
        var direction = Input.GetAxisRaw("Horizontal");
        _playerAnimator.SetFloat(Horizontal, Mathf.Abs(direction));
        if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _desiredVelocity = Vector2.left;
        } else if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _desiredVelocity = Vector2.right;
        }
        else
        {
            _desiredVelocity = Vector2.zero;
        }

        _rigidbody.drag = _desiredVelocity == Vector2.zero ? stoppingDrag : 1f;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_desiredVelocity * moveSpeed , ForceMode2D.Force);
        
    }*/

    public void OnWalkLeft()
    {
        
    }
}
