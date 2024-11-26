using UnityEngine;

public class PushingObject : MonoBehaviour
{
    public float pushForce = 10f; // The force applied to the object when pushing.

    private void OnCollisionStay(Collision collision)
    {
        // Check if the collided object has a Rigidbody and is tagged as Pushable
        if (collision.rigidbody != null && collision.gameObject.CompareTag("Pushable"))
        {
            ApplyPushForce(collision);
        }
    }

    private void ApplyPushForce(Collision collision)
    {
        // Calculate the direction to push the object based on the player's movement
        Vector3 pushDirection = collision.transform.position - transform.position;
        pushDirection.y = 0; // Prevent vertical force
        pushDirection.Normalize();

        // Apply force to the object
        collision.rigidbody.AddForce(pushDirection * pushForce, ForceMode.Force);
    }
}

