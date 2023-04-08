using System;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask groundLayer;
    
    public bool isGrounded { get; private set; }

    private void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
    }
}