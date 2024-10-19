using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 2.0f;
    public InputActionReference move;
    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(x:_moveDirection.x*moveSpeed, y:0, z:_moveDirection.y*moveSpeed);
    }
}
