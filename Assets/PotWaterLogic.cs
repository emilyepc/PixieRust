using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotWaterLogic : MonoBehaviour
{
    public GameObject objectToCheck; // The GameObject to check if active
    public GameObject objectToActivate; // The GameObject to activate
    public Collider triggerZone; // The Collider to check if the player is inside

    private bool isPlayerInside = false; // Tracks if the player is inside the collider
    private bool isActivated = false; // Tracks if the object has been activated

    void Start()
    {
        if (triggerZone == null)
        {
            Debug.LogError("Trigger Zone Collider is not assigned!");
        }
    }

    void Update()
    {
        if (objectToCheck != null && objectToActivate != null && triggerZone != null)
        {
            // Activate the object once the condition is met, if not already activated
            if (objectToCheck.activeSelf && isPlayerInside && !isActivated)
            {
                objectToActivate.SetActive(true);
                isActivated = true; // Mark as activated
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}

