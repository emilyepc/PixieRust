using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamActivator : MonoBehaviour
{
    [Header("References")]
    public GameObject targetObject; // The object to activate
    public GameObject gate;
    public GameObject monitoredObject; // The object to check Y position
    public GameObject conditionObject1; // The first object to check if active
    public GameObject conditionObject2; // The second object to check if active

    private void Update()
    {
        if (IsConditionMet())
        {
            Debug.Log("All conditions met. Activating targetObject and deactivating gate.");
            targetObject.SetActive(true);
            gate.SetActive(false);
        }
        else
        {
            Debug.Log("Conditions not met. Deactivating targetObject and activating gate.");
            targetObject.SetActive(false);
            gate.SetActive(true);
        }
    }

    private bool IsConditionMet()
    {
        // Check if the monitored object's Y position matches
        bool isYPositionMatch = Mathf.Approximately(monitoredObject.transform.position.y, 2.094789f);
        if (!isYPositionMatch)
        {
            Debug.Log($"Y position mismatch. Expected: 1.521789, Actual: {monitoredObject.transform.position.y}");
        }

        // Check if both condition objects are active
        bool isConditionObject1Active = conditionObject1.activeSelf;
        bool isConditionObject2Active = conditionObject2.activeSelf;
        bool areConditionObjectsActive = isConditionObject1Active && isConditionObject2Active;

        if (!isConditionObject1Active)
        {
            Debug.Log("ConditionObject1 is not active.");
        }
        if (!isConditionObject2Active)
        {
            Debug.Log("ConditionObject2 is not active.");
        }

        // Return true only if all conditions are met
        return isYPositionMatch && areConditionObjectsActive;
    }
}


