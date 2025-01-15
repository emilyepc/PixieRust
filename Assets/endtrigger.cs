using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for scene loading

public class endtrigger : MonoBehaviour
{
    private bool playerInRange = false;  // To check if the player is inside the trigger zone

    public int sceneIndexToLoad;  // Public variable to assign the scene index in the Inspector

    void Update()
    {
        // Check if the player is in range and presses the "E" key
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Load the scene based on the specified index
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }

    // When the player enters the trigger collider, set playerInRange to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure this only applies to the player
        {
            playerInRange = true;
        }
    }

    // When the player leaves the trigger collider, set playerInRange to false
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure this only applies to the player
        {
            playerInRange = false;
        }
    }
}


