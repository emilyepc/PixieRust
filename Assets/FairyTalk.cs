using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class FairyTalk : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject  FairyTalkPanel, PlayerCapsule, UI, Camera;
    public TMP_Text FairyTalkText;
    private int currentDialogueIndex = 0;
    private string[] dialogues = { "yadadadad", "yadadaaaaaaaaaaaaaaaaaaa", "" };

    // Start is called before the first frame update
    void Start()
    {
        FairyTalkPanel.SetActive(false);
        PlayerCapsule.SetActive(true);
        UI.SetActive(false);
        Camera.SetActive(false);
        
    }

    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
            if (currentDialogueIndex < dialogues.Length)
            {
                FairyTalkText.text = dialogues[currentDialogueIndex];
                currentDialogueIndex++;

                // If all dialogues have been displayed, hide the dialogue panel and show other UI elements
                if (currentDialogueIndex >= dialogues.Length)
                {
                    EndDialogue();
                }
            }
        }
    }
    void EndDialogue()
    {
        FairyTalkPanel.SetActive(false);
        
        PlayerCapsule.SetActive(true);
        UI.SetActive(false);
        Camera.SetActive(false);
        
        currentDialogueIndex = 0;
    }
    void StartDialogue()
    {
        FairyTalkPanel.SetActive(true);
        Camera.SetActive(true);
        
        PlayerCapsule.SetActive(false);
        UI.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            isInsideTrigger = false;

        }
    }
}

