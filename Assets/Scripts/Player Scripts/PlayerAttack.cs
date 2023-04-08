using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private PlayerDetection _playerDetection;
    private bool _tryingToAttack;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerDetection = GetComponent<PlayerDetection>();
        _tryingToAttack = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }
}
