using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{
    public Camera Camara1;
    public Camera Camara3;
    public Camera CamaraZ;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCamaraChange()
    {
        Debug.Log("camara");
    }
}
