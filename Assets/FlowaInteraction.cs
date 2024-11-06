using UnityEngine;

public class FlowaInteraction : MonoBehaviour
{
    // Reference to the 3D Text object
    public GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the text
        if (textObject != null)
        {
            textObject.SetActive(false);
        }
    }

    // Detect when the player enters the collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player (using a tag for simplicity)
        if (other.CompareTag("Player"))
        {
            // Make the text object visible
            if (textObject != null)
            {
                textObject.SetActive(true);
            }
        }
    }

    // Detect when the player exits the collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the text when the player leaves the collider
            if (textObject != null)
            {
                textObject.SetActive(false);
            }
        }
    }
}

