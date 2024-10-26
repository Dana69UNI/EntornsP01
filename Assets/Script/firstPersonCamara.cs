using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class firstPersonCamara : MonoBehaviour
{

    public Transform playerBody;
    public float mouseSensitivity = 50f;
    public InputActionReference lookAction;

    private float xRotation = 0f;
    private Vector2 lookInput;
    private PlayerMovement playerMovement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement = playerBody.GetComponent<PlayerMovement>(); // Referencia a PlayerMovement
    }

    void OnEnable()
    {
        lookAction.action.performed += OnLookInput;
        lookAction.action.Enable();
    }

    void OnDisable()
    {
        lookAction.action.performed -= OnLookInput;
        lookAction.action.Disable();
    }

    void Update()
    {
        
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

       
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        playerMovement.ApplyRotation(mouseX); // Rotación horizontal manejada por PlayerMovement
    }

    private void OnLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}

//Este codigo lo vamos a hacer cogiendo los inputs manualmente porque cuando lo haciamos con el NewInputSystem habia un conflicto con el
//script de playerMovement, que no sabemos solucionar.
//public float mouseSensitivity = 100f; // Sensibilidad del ratón
//public Transform playerBody;          // Referencia al cuerpo del jugador

//private float xRotation = 0f;         // Control de la rotación en el eje X
//void Update()
//{
//handleGamepad();
//handleMouse();




//}

//private void handleGamepad()
//{
//    float joyX = Input.GetAxis("RightStickHorizontal") * mouseSensitivity * Time.deltaTime;
//    float joyY = Input.GetAxis("RightStickVertical") * mouseSensitivity * Time.deltaTime;


//    xRotation -= joyY;
//    xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación vertical


//    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


//    playerBody.Rotate(Vector3.up * joyX);
//}

//private void handleMouse()
//{

//    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


//    xRotation -= mouseY;
//    xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación vertical


//    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


//    playerBody.Rotate(Vector3.up * mouseX);
//}
//}
