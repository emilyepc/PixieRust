using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Unity.UI;

public class FairyTalk3 : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject PlayerCapsule, UI, Camera;
    public TMP_Text FairyTalkText;
    private int currentDialogueIndex = 0;
    private string[] dialogues = { "Thank you for your help, kind fae", "now, every part of me is soaked but i kept this safe", "you might find it useful, try use it like you use the water rune! Except its fire.", "The train station seems to be out of bounds but i'm sure you can find a way in....", "" };

    // Start is called before the first frame update
    void Start()
    {

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


        PlayerCapsule.SetActive(true);
        UI.SetActive(false);
        Camera.SetActive(false);

        currentDialogueIndex = 0;
    }
    void StartDialogue()
    {

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
