using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollectRune : MonoBehaviour
{
    public GameObject objectToDisappear; 
    public Collider triggerZone; 

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToDisappear != null)
            {
                objectToDisappear.SetActive(false); 
            }
        }
    }
}

