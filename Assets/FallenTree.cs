using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FallenTree : MonoBehaviour
{
    // References to GameObjects
    public GameObject objectToCheck;         // The GameObject to check if active
    public GameObject objectToDeactivate;   // The GameObject to deactivate if the first is active
    public Collider triggerZone;            // The Collider to check if the player is inside

    private bool isPlayerInside = false;    // Tracks if the player is inside the collider

    void Start()
    {
        if (triggerZone == null)
        {
            Debug.LogError("Trigger Zone Collider is not assigned!");
        }
    }

    void Update()
    {
        // Ensure all necessary references are assigned
        if (objectToCheck != null && objectToDeactivate != null && triggerZone != null)
        {
            // Check if the first GameObject is active and the player is inside the trigger zone
            if (objectToCheck.activeSelf && isPlayerInside)
            {
                // Deactivate the second GameObject
                objectToDeactivate.SetActive(false);
            }
            else
            {
                // Optionally, reactivate the second GameObject if needed
                objectToDeactivate.SetActive(true);
            }
        }
    }

    // Detect when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    // Detect when the player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}

