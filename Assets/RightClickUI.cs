using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightClickUI : MonoBehaviour
{
    public GameObject button; // Assign the button in the inspector
    public GameObject particleSystemObject; // Assign the Particle System GameObject in the inspector
    private bool isButtonVisible = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            ToggleButtonVisibility();
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
            particleSystemObject.SetActive(true); // Activate the Particle System GameObject
            Debug.Log("Particle System activated!");
        }
        button.SetActive(false); // Hide the button
    }
}


