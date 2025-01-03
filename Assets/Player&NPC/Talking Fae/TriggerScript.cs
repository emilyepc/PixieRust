using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TriggerScript : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public string Dialogue;
    public TMP_Text DialogueOBJ;

    void Start()
    {
        // Initialize the dialogue text object with the provided dialogue
        if (DialogueOBJ != null)
        {
            DialogueOBJ.text = Dialogue;
        }
        else
        {
            Debug.LogWarning("DialogueOBJ is not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;
            // Optionally, update or modify DialogueOBJ here
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            isInsideTrigger = false;
            // Optionally, reset or clear DialogueOBJ here
        }
    }
}
