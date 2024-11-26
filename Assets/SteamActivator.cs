using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamActivator : MonoBehaviour

{
    [Header("References")]
    public GameObject targetObject; // The object to activate
    public GameObject monitoredObject; // The object to check Y position
    public GameObject conditionObject1; // The first object to check if active
    public GameObject conditionObject2; // The second object to check if active

    private void Update()
    {
        if (IsConditionMet())
        {
            targetObject.SetActive(true);
        }
        else
        {
            targetObject.SetActive(false);
        }
    }

    private bool IsConditionMet()
    {
        // Check if the monitored object's Y position matches
        bool isYPositionMatch = Mathf.Approximately(monitoredObject.transform.position.y, 1.886875f);

        // Check if both condition objects are active
        bool areConditionObjectsActive = conditionObject1.activeSelf && conditionObject2.activeSelf;

        // Return true only if all conditions are met
        return isYPositionMatch && areConditionObjectsActive;
    }
}

