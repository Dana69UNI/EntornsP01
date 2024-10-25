using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Camera playerCamera;
    public float moveSpeed = 5.0f; //Este sera el multiplicador del input del movimiento
    public float walkingSpeed = 5.0f;  //Referencia para modificar moveSpeed, así no ponemos un numero arbitrario, sino que ya esta declarado
    public float sprintSpeed = 10.0f;//Referencia para modificar moveSpeed, pa correr
    public InputActionReference move;

    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        OnMovement();
    }

    private void OnMovement()
    {
     
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

       
        Vector3 moveDirection = (right * _moveDirection.x + forward * _moveDirection.y).normalized;

       
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

    public void OnSprintStart() //Al haber separado Sprint en Start y end, podemos usar tal cual el OnSprintxxx de funcion y no tener que hacer booleanas ni nada del estilo
    {
        moveSpeed = sprintSpeed;
    }

    public void OnSprintEnd()
    {
        moveSpeed = walkingSpeed;
    }
}
