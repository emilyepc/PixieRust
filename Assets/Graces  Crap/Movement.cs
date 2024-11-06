using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    public AudioSource walking;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        walking.Stop(); // Ensure the walking sound is stopped at the start
    }

    void Update()
    {
        // Get movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a normalized movement direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Handle movement if there's input
        if (direction.magnitude >= 0.1f)
        {
            // Move the character
            Vector3 moveDir = direction * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDir);

            // Rotate the character towards the movement direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));

            // Play walking sound if the character is moving
            if (!walking.isPlaying)
                walking.Play();
        }
        else
        {
            // Stop walking sound if not moving
            if (walking.isPlaying)
                walking.Stop();
        }

        // Handle jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the player is grounded using collision with the "Ground" tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Set isGrounded to false if the player exits the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}






