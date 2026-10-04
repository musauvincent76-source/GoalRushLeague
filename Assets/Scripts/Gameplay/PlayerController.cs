using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 180f;
    public Rigidbody rb;

    private Vector3 moveDirection;
    private bool isSprinting;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
        HandleRotation();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    private void HandleMovement()
    {
        float speed = isSprinting ? sprintSpeed : moveSpeed;
        rb.velocity = moveDirection * speed;
    }

    private void HandleRotation()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
    }
}
