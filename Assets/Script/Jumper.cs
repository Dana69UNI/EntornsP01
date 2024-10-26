using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Rigidbody rb;
    PlayerInputActions inputActions;
    private bool isGrounded;
    private float distGround = 1f;
    public void OnJumpPress()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector3(x: 0, y: 6f, z: 0);
           
        }
       
    }

    public void OnJumpRelease()
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(x: 0, y: 0, z: 0);
        }

    }

    private void FixedUpdate()
    {
        Grounded();
    }

    public void Grounded()
    {
        if(Physics.Raycast(transform.position, Vector3.down, distGround + 0.1f))
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
            
        }
    }


}
