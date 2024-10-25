using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{
    public Camera Camara1;
    public Camera Camara3;
    public CinemachineFreeLook Cinemac3;
    [SerializeField] PlayerMovement _playerMovement; //importamos el script de playermovement para cambiar la booleana de isFPS
    private void Start()
    {
        Camara1.enabled = false;
        
        Camara3.enabled = true;
        Cinemac3.gameObject.SetActive(true);

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
            _playerMovement.isFPSStatus();
            Camara3.enabled = true;
            Cinemac3.gameObject.SetActive(true);
        }
        else
        { 
            Camara3.enabled = false;
            _playerMovement.isFPSStatus();
            Cinemac3.gameObject.SetActive(false);
            Camara1.enabled = true;
        }
    }
}
