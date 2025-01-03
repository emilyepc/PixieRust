using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellLogic : MonoBehaviour
{
    public GameObject Waterempty, Waterfull, UI, particlesystem;
    public FairyTalk script;
    // Start is called before the first frame update
    void Start()
    {
        
        // Initial states
        Waterempty.SetActive(true);
        Waterfull.SetActive(false);
        //UI.SetActive(false);
        particlesystem.SetActive(false);

        // Debug messages to confirm initialization
        Debug.Log("WellLogic initialized. Particle System set to inactive.");

    }

    // Trigger event when another collider enters the trigger collider
    private void OnTriggerStay(Collider other)
    {
        // Check if the player enters the collider and if the particle system is already active
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger.");
            //particlesystem.SetActive(true);

            // Checking if particle system is active
            if (particlesystem.activeSelf)
            {
                Debug.Log("Particle system is active. Filling well.");

                // Activate full well, deactivate empty well, and show UI
                Waterempty.SetActive(false);
                Waterfull.SetActive(true);
                //UI.SetActive(true);
                
            }
            else
            {
                Debug.Log("Particle system is NOT active. Cannot fill well.");
            }
        }
    }

    // Trigger event when the player exits the collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the collider
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger.");

            // Hide UI, if needed
            //UI.SetActive(false);
        }
    }
}

