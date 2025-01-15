using UnityEngine;

public class ConditionalAction: MonoBehaviour
{
    [Header("References")]
    public GameObject button;                   // Assign the button in the inspector
    public GameObject particleSystemObject;     // Assign the Particle System GameObject in the inspector
    public GameObject uiObject;                 // Assign the UI GameObject (can be any GameObject) in the inspector
    public Animator animator;                   // Assign the Animator component in the inspector
    public GameObject activationObject;         // The object that determines whether actions happen

    [Header("State Variables")]
    public bool isButtonVisible = false;
    float particleTimer = 3.0f;                 // 5-second timer for the particle system
    public bool isParticleActive = false;
    public Vector3 direction;

    void Update()
    {
        // Only execute logic if the activationObject is inactive
        if (activationObject != null && !activationObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(1)) // Right mouse button
            {
                ToggleButtonOn();
                uiObject.SetActive(true);
            }

            Vector3 direction = InputHandler.GetMovementDirection();

            if (isParticleActive)
            {
                // Countdown the timer
                particleTimer -= Time.deltaTime;

                // Check if 5 seconds have passed
                if (particleTimer <= 0)
                {
                    // Stop the particle system and reset UI
                    particleSystemObject.SetActive(false);
                    uiObject.SetActive(false);

                    // Reset timer and particle activity state
                    particleTimer = 5.0f;
                    isParticleActive = false;

                    // Reset the animation state
                    if (animator != null)
                    {
                        animator.SetBool("IsThrowing", false); // Stop the animation
                    }
                }
            }
        }
    }

    void ToggleButtonOn()
    {
        isButtonVisible = true;
        button.SetActive(isButtonVisible);
    }

    void ToggleButtonOff()
    {
        isButtonVisible = false;
        button.SetActive(isButtonVisible);
    }

    public void OnButtonPress()
    {
        // Only allow button press actions if the activationObject is inactive
        if (activationObject != null && !activationObject.activeSelf)
        {
            Debug.Log("Button pressed!");

            // If player is using particle system and moving at the same time
            if (direction.magnitude >= 0.1f && animator != null)
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsThrowing", false);
                Debug.Log("Moving throw working");
            }

            if (particleSystemObject != null)
            {
                // Start the particle system and disable the UI object
                particleSystemObject.SetActive(true);
                uiObject.SetActive(false);
                isParticleActive = true;
                Debug.Log("Particle System activated!");
            }

            // Hide the button immediately after press
            button.SetActive(false);
        }
    }

    public bool GetIsParticleActive()
    {
        return isParticleActive;
    }
}

