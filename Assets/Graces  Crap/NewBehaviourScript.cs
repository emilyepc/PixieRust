using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Vector3 offset = new Vector3(10f, 15f, -10f); // Offset for the isometric view
    public float followSpeed = 5f; // Speed at which the camera follows the player

    private void LateUpdate()
    {
        if (player != null)
        {
            // Desired camera position
            Vector3 desiredPosition = player.position + offset;

            // Smoothly move camera towards the player's position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Keep the camera looking at the player
            transform.LookAt(player);
        }
    }
}

