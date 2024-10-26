using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherControl : MonoBehaviour
{
    public WindController windController;

  

    private void Update()
    {
        
        Vector3 windDir = windController.windDirection;
        Quaternion targetRotation = Quaternion.LookRotation(windDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * windController.windForce);
    }
}
