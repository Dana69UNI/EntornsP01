using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator Puerta;

    private void OntriggerEnter(Collider other)
    {
        Puerta.Play("Open");
    }
    private void OntriggerExit(Collider other)
    {
        Puerta.Play("close");
    }
}
