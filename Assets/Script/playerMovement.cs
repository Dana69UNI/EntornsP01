using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5.0f; //Este sera el multiplicador del input del movimiento
    public float walkingSpeed = 5.0f; //Referencia para modificar moveSpeed, así no ponemos un numero arbitrario, sino que ya esta declarado
    public float sprintSpeed = 10.0f; //Referencia para modificar moveSpeed, pa correr
    public InputActionReference move;
    PlayerInputActions inputActions;
    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        
    }
    private void FixedUpdate()
    {
        OnMove();
    }
    private void OnMove()
    {
        rb.velocity = new Vector3(x: _moveDirection.x * moveSpeed, y: rb.velocity.y, z: _moveDirection.y * moveSpeed);

    }
    public void OnSprintStart() //Al haber separado Sprint en Start y end, podemos usar tal cual el OnSprintxxx de funcion y no tener que hacer booleanas ni nada del estilo
    {
        moveSpeed = sprintSpeed;
    }
    public void OnSprintEnd()
    {
        moveSpeed = walkingSpeed;
    }

    public void OnJumpPress()
    {
        rb.velocity = new Vector3(x: 0, y: 10f * 0.8f , z: 0);
    }

    public void OnJumpRelease()
    {
        rb.velocity = new Vector3(x: 0, y: 0, z: 0);
    }

}
               