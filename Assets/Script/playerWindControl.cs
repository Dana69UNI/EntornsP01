using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWindControl : MonoBehaviour
{
    [SerializeField] WindController _windControl;


    private void OnWindDirectionRandom()
    {
        _windControl.windDirection = new Vector3(Mathf.Sin(Time.time), 0, Mathf.Cos(Time.time)).normalized; // Ejemplo: viento cambia con el tiempo
        Debug.Log("DireccionRandom");
    }
}
