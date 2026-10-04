using Fusion;
using UnityEngine;

public class BallControllerNetworked : NetworkBehaviour
{
    [SerializeField] private float kickForce = 20f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float friction = 0.95f;

    private Rigidbody rb;

    public override void Spawned()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void FixedUpdateNetwork()
    {
        if (rb == null)
            return;

        ApplyFriction();
        LimitSpeed();
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_KickBall(Vector3 direction)
    {
        rb.velocity = direction.normalized * kickForce;
        Debug.Log("Ball kicked!");
    }

    private void ApplyFriction()
    {
        rb.velocity *= friction;
    }

    private void LimitSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        rb.velocity = Vector3.zero;
        Debug.Log("Ball reset to position: " + newPosition);
    }
}
