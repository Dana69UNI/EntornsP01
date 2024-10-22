using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{
    public Camera Camara1;
    public Camera Camara3;

    private void Start()
    {
        Camara1.enabled = false;
        
        Camara3.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCamaraChange()
    {
        if(Camara1.enabled == true)
        {
            Camara1.enabled = false;
            Camara3.enabled = true;
        }
        else
        { 
            Camara3.enabled = false;
            Camara1.enabled = true;
        }
    }
}
