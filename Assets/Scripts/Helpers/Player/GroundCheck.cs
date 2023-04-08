using System;
using UnityEngine;

namespace Helpers.Player
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private float groundCheckRadius;
        
        public bool IsGrounded { get; private set; }

        private void Update()
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
            Debug.Log(IsGrounded);
        }
    }
}