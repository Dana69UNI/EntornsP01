using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 7.0f;
    public InputActionReference move;
    PlayerInputActions inputActions;
    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        
    }
    private void FixedUpdate()
    {
        onMove();
    }
    private void onMove()
    {
        rb.velocity = new Vector3(x: _moveDirection.x * moveSpeed, y: rb.velocity.y, z: _moveDirection.y * moveSpeed);
        

    }

    public void onSprint()
    {
        Debug.Log("sprint");
    }
    
}
