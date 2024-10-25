using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    bool _Sprint = false;
    bool _Jump = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
       
    }

    private void Update()
    {
        
    }
    private void OnMovement()
    {
        if (!_Sprint || !_Jump)
        {
            _animator.SetBool("isWalking", true);
        }
       
        
    }
    private void OnMovementStop()
    {
        _animator.SetBool("isWalking", false);
    }
    private void OnSprintStart()
    {
        _Sprint = true;
        _animator.SetBool("isWalking", false);
      
        _animator.SetBool("isRunning", true);
    }
    private void OnSprintEnd()
    {
        _Sprint = false;
        _animator.SetBool("isRunning", false);
        
    }
    private void OnJumpPress()
    {
        _animator.SetBool("isJumping", true);

    }
    private void OnJumpRelease()
    {
        _animator.SetBool("isJumping", false);

    }
}
