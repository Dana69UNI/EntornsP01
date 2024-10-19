using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penduloSpingScript : MonoBehaviour
{
    LineRenderer lr;
    public Transform lineStart;  // Asigna tu objeto de inicio en el inspector
    public Transform lineEnd;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;
        lr.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, lineStart.position);
        lr.SetPosition(1, lineEnd.position);
    }
}



