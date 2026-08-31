using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    public GameObject Head;
    public Transform RayCastPos;
    public float MoveSpeed;
    public float SprintSpeed;
    public Rigidbody rb;
    private Vector2 moveDir;
    private Vector3 vel;
    private float currentSpeed;
    private bool isSprinting;

    public float sensitivity = 1.2f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        Vector3 move = transform.forward * moveDir.y + transform.right * moveDir.x;

        currentSpeed = isSprinting ? MoveSpeed + SprintSpeed : MoveSpeed;
        vel = (move * currentSpeed * Time.deltaTime);
        vel.y = rb.linearVelocity.y;

        // Read mouse movement axes
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Accumulate values (Invert Y for standard looking controls)
        rotationX += mouseX;
        rotationY -= mouseY;

        // Optional: Clamp vertical look to look straight up or down
        rotationY = Mathf.Clamp(rotationY, -12f, 30f);

        // Apply rotation
        Head.transform.localRotation = Quaternion.Euler(rotationY, 0, 0f);
        transform.localRotation = Quaternion.Euler(0, rotationX, 0f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = vel;
    }
}
