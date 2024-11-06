using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightClickUI : MonoBehaviour
{
    public GameObject button;                   // Assign the button in the inspector
    public GameObject particleSystemObject;     // Assign the Particle System GameObject in the inspector
    public Canvas uiCanvas;                     // Assign the main UI canvas in the inspector

    private bool isButtonVisible = false;
    private float particleTimer = 5.0f;         // 5-second timer for the particle system
    private bool isParticleActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            ToggleButtonVisibility();
            uiCanvas.enabled = true;
        }

        if (isParticleActive)
        {
            // Countdown the timer
            particleTimer -= Time.deltaTime;

            // Check if 5 seconds have passed
            if (particleTimer <= 0)
            {
                // Stop the particle system and reset UI
                particleSystemObject.SetActive(false);
                uiCanvas.enabled = false;

                // Reset timer and particle activity state
                particleTimer = 5.0f;
                isParticleActive = false;
            }
        }
    }

    void ToggleButtonVisibility()
    {
        isButtonVisible = !isButtonVisible;
        button.SetActive(isButtonVisible);
    }

    public void OnButtonPress()
    {
        Debug.Log("Button pressed!");

        if (particleSystemObject != null)
        {
            // Start the particle system and disable the main UI canvas
            particleSystemObject.SetActive(true);
            uiCanvas.enabled = false;
            isParticleActive = true;
            Debug.Log("Particle System activated!");
        }

        // Hide the button immediately after press
        button.SetActive(false);
    }
    public bool GetIsParticleActive()
    {
        return isParticleActive;
    }
}



