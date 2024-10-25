using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator Puerta;
    private void OnTriggerEnter(Collider other)
    {
        Puerta.Play("Open");
    }
    private void OnTriggerExit(Collider other)
    {
        Puerta.Play("close");
    }

   

}
