using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpHeight = 8.0f;
    private bool isJumping = false;
    private Vector3 moveDirection = Vector3.zero;
    public GameDataScriptableObject gameDataValues;

    private Rigidbody rb;
    private Camera cam;

    void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Restrict rotation of the Rigidbody
        rb.freezeRotation = true;

        // Get the Camera component
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Get the horizontal and vertical movement input (WASD by default)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (gameDataValues.isWorking)
        {
            moveHorizontal = 0;
            moveVertical = 0;
        }
        if (gameDataValues.isConfused)
        {
            moveHorizontal *= -1;
            moveVertical *= -1;
        }

        // Calculate the movement direction
        moveDirection = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player object around the y-axis
        transform.Rotate(0, mouseX, 0);

        // Calculate the new vertical rotation
        float newRotationX = cam.transform.localEulerAngles.x - mouseY;

        // Ensure the new rotation stays within the desired range
        if (newRotationX <= 180)
        {
            newRotationX = Mathf.Clamp(newRotationX, -90f, 90f);
        }
        else
        {
            newRotationX = Mathf.Clamp(newRotationX, 270f, 360f);
        }

        // Apply the vertical rotation to the camera
        cam.transform.localEulerAngles = new Vector3(newRotationX, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);

        // Check for jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.VelocityChange);
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the player collides with the ground, they are no longer jumping
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
