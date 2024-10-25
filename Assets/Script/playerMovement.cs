using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Camera playerCamera; //Importo camara de 3ra persona para manejar el movimiento segun esta
    public Camera fpsCamera; //Importo camara de 1ra persona para manejar el movimiento segun esta
    public float moveSpeed = 5.0f; //Este sera el multiplicador del input del movimiento
    public float walkingSpeed = 5.0f;  //Referencia para modificar moveSpeed, así no ponemos un numero arbitrario, sino que ya esta declarado
    public float sprintSpeed = 10.0f;//Referencia para modificar moveSpeed, pa correr
    public InputActionReference move;
    bool isFPS = false; //Bool para saber si estoy en primera persona o no y manejar el movimiento diferente

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
        if (!isFPS) //Si la camara no esta en primera persona normaliza el movimiento segun donde esta mirando la camara de 3ra persona
        {
            Vector3 forward = playerCamera.transform.forward;
            Vector3 right = playerCamera.transform.right;


            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();


            Vector3 moveDirection = (right * _moveDirection.x + forward * _moveDirection.y).normalized;

            if (moveDirection.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * 30f);
            }

            rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        }
        else //en cambio si esta en primera lo normaliza segun esta
        {

            Vector3 forward2 = fpsCamera.transform.forward;
            Vector3 right2 = fpsCamera.transform.right;


            forward2.y = 0;
            right2.y = 0;

            forward2.Normalize();
            right2.Normalize();


            Vector3 moveDirection = (right2 * _moveDirection.x + forward2 * _moveDirection.y).normalized;


            rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        }

    }

    public void OnSprintStart() //Al haber separado Sprint en Start y end, podemos usar tal cual el OnSprintxxx de funcion y no tener que hacer booleanas ni nada del estilo
    {
        moveSpeed = sprintSpeed;
    }

    public void OnSprintEnd()
    {
        moveSpeed = walkingSpeed;
    }

    public void isFPSStatus() //esta funcion cambia la booleana de true a false y de false a true cada que se invoca. (la invocamos en el script de camaraController)
    {
        isFPS = !isFPS;
    }

}
