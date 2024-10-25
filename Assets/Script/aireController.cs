using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aireController : MonoBehaviour
{
    public Rigidbody rb;
    bool isFloating = false;
    private void OnTriggerEnter(Collider other)
    {
        isFloating = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isFloating = false;
    }
    private void FixedUpdate()
    {
        if (isFloating)
        {
            rb.velocity = Vector3.up * 5f;
        }
    }

    
}
