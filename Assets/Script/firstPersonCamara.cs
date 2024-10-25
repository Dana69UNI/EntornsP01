using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonCamara : MonoBehaviour
{

    //Este codigo lo vamos a hacer cogiendo los inputs manualmente porque cuando lo haciamos con el NewInputSystem habia un conflicto con el
    //script de playerMovement, que no sabemos solucionar.
    public float mouseSensitivity = 100f; // Sensibilidad del ratón
    public Transform playerBody;          // Referencia al cuerpo del jugador

    private float xRotation = 0f;         // Control de la rotación en el eje X

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //handleGamepad();
        handleMouse();



        
    }

    //private void handleGamepad()
    //{
    //    float joyX = Input.GetAxis("RightStickHorizontal") * mouseSensitivity * Time.deltaTime;
    //    float joyY = Input.GetAxis("RightStickVertical") * mouseSensitivity * Time.deltaTime;


    //    xRotation -= joyY;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación vertical


    //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


    //    playerBody.Rotate(Vector3.up * joyX);
    //}

    private void handleMouse()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación vertical


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        playerBody.Rotate(Vector3.up * mouseX);
    }
}
