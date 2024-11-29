using UnityEngine;

public class DialogueSequence: MonoBehaviour
{
    public GameObject objectToCheck; // The GameObject to monitor
    public GameObject objectToActivate; // The GameObject to activate
    public GameObject objectToDeactivate; // The GameObject to deactivate

    void Update()
    {
        if (objectToCheck != null && objectToActivate != null && objectToDeactivate != null)
        {
            if (!objectToCheck.activeSelf)
            {
                if (!objectToActivate.activeSelf)
                {
                    objectToActivate.SetActive(true);
                }
                if (objectToDeactivate.activeSelf)
                {
                    objectToDeactivate.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogError("Assign all objects in the inspector!");
        }
    }
}


