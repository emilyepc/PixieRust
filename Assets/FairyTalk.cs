using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class FairyTalk : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject PlayerCapsule, UI, Camera;
    public TMP_Text FairyTalkText;
    private int currentDialogueIndex = 0;

    private string[] dialogues1 = { "Hellllp!!!!", "Oh you there! I fell in and I cant get out...", "I cant climb up with that metal chain but maybe if there was a way to get this water to rise up...", "If you look for the water wheels you might be able to find something to help", "" };
    private string[] dialogues2 = { "Hellllp!!!!", "Oh! It's you again!", "You have something new on you?", "Maybe you can use it to help me get out of here?", "" };
    private string[] dialogues3 = { "Thank you for your help, kind fae", "Now, every part of me is soaked but I kept this safe", "You might find it useful, try use it like you use the water rune!", "The train station seems to be out of bounds but I'm sure you can find a way in...", "" };

    public bool WaterRuneAcess = false;
    public bool WellPuzzleStatus = false;

    void Start()
    {
        Debug.Log("FairyTalk script initialized.");
        PlayerCapsule.SetActive(true);
        UI.SetActive(false);
        Camera.SetActive(false);
    }

    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player pressed E inside the trigger.");
            Debug.Log($"Current State -> WaterRuneAcess: {WaterRuneAcess}, WellPuzzleStatus: {WellPuzzleStatus}");

            StartDialogue();

            string[] currentDialogue = GetCurrentDialogue();
            Debug.Log($"Selected dialogue set: {currentDialogue}");

            if (currentDialogueIndex < currentDialogue.Length)
            {
                FairyTalkText.text = currentDialogue[currentDialogueIndex];
                Debug.Log($"Displaying dialogue: {currentDialogue[currentDialogueIndex]}");
                currentDialogueIndex++;

                if (currentDialogueIndex >= currentDialogue.Length)
                {
                    Debug.Log("All dialogues displayed. Ending dialogue.");
                    EndDialogue();
                }
            }
            else
            {
                Debug.Log("No dialogues to display. Ending dialogue.");
                EndDialogue();
            }
        }
    }

    string[] GetCurrentDialogue()
    {
        if (!WaterRuneAcess && !WellPuzzleStatus)
        {
            Debug.Log("Fetching dialogues1: No WaterRuneAccess and No WellPuzzleStatus.");
            return dialogues1;
        }

        if (WaterRuneAcess && !WellPuzzleStatus)
        {
            Debug.Log("Fetching dialogues2: WaterRuneAccess but No WellPuzzleStatus.");
            return dialogues2;
        }

        if (WaterRuneAcess && WellPuzzleStatus)
        {
            Debug.Log("Fetching dialogues3: WaterRuneAccess and WellPuzzleStatus.");
            return dialogues3;
        }

        Debug.LogWarning("Unexpected state: Returning empty dialogue set.");
        return new string[0]; // Fallback in case conditions fail
    }

    void StartDialogue()
    {
        Debug.Log("Starting dialogue.");
        Camera.SetActive(true);
        PlayerCapsule.SetActive(false);
        UI.SetActive(true);
    }

    void EndDialogue()
    {
        Debug.Log("Ending dialogue.");
        PlayerCapsule.SetActive(true);
        UI.SetActive(false);
        Camera.SetActive(false);
        currentDialogueIndex = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area.");
            enteredTrigger?.Invoke();
            isInsideTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger area.");
            exitedTrigger?.Invoke();
            isInsideTrigger = false;
        }
    }
}
