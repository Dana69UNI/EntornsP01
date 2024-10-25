using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehaviour : MonoBehaviour
{
    bool isDoorLocked=true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if(!isDoorLocked)
            {
                StartCoroutine(DoorOpener());
            }
            
        }
    }
    private IEnumerator DoorOpener()
    {
        float duration = 3f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Mueve la puerta hacia arriba
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void lockStatus()
    {
        isDoorLocked = !isDoorLocked;
    }
}
