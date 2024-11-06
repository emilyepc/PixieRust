using UnityEngine;

public class WellLogic : MonoBehaviour
{
    public GameObject Waterempty, Waterfull, UI;
    public RightClickUI rightClickScript;  // Reference to RightClickUI script

    // Start is called before the first frame update
    void Start()
    {
        // Set initial states
        Waterempty.SetActive(true);
        Waterfull.SetActive(false);
        UI.SetActive(false);

        // Ensure that we have a reference to RightClickUI
        if (rightClickScript == null)
        {
            Debug.LogError("RightClickUI script reference is missing in WellLogic. Please assign it in the Inspector.");
        }
    }

    // Trigger event when the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if isParticleActive in RightClickUI is true using the getter method
            if (rightClickScript != null && rightClickScript.GetIsParticleActive())
            {
                Debug.Log("Particle system is active in RightClickUI and player is in collider. Filling well.");

                // Activate full well, deactivate empty well, and show UI
                Waterempty.SetActive(false);
                Waterfull.SetActive(true);
                UI.SetActive(true);
            }
            else
            {
                Debug.Log("Particle system is not active or RightClickUI reference is missing.");
            }
        }
    }

    // Trigger event when the player exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger.");

            // Hide UI when the player exits
            UI.SetActive(false);
        }
    }
}
