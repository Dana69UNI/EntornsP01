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
        lookInput = Vector2.zero; //limpia el lookInput para evitar problemas
    }

    private void OnLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}

