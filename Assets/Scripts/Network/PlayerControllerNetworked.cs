using Fusion;
using UnityEngine;

public class PlayerControllerNetworked : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float rotationSpeed = 180f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private NetworkRunner runner;

    public override void Spawned()
    {
        rb = GetComponent<Rigidbody>();
        runner = FindObjectOfType<NetworkRunner>();
    }

    public override void FixedUpdateNetwork()
    {
        if (!HasInputAuthority || rb == null)
            return;

        HandleNetworkInput();
        HandleRotation();
    }

    private void HandleNetworkInput()
    {
        if (runner.TryGetInputStruct(out NetworkInputData input))
        {
            moveDirection = new Vector3(input.Horizontal, 0f, input.Vertical).normalized;

            float speed = input.IsSprinting ? sprintSpeed : moveSpeed;
            rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);

            if (input.IsShootingButton)
            {
                HandleShoot();
            }

            if (input.IsTackleButton)
            {
                HandleTackle();
            }
        }
    }

    private void HandleRotation()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleShoot()
    {
        Debug.Log("Player shot!");
    }

    private void HandleTackle()
    {
        Debug.Log("Player tackled!");
    }
}
