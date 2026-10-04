using UnityEngine;

public class BallController : MonoBehaviour
{
    public float kickForce = 20f;
    public float maxSpeed = 30f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        LimitSpeed();
    }

    public void KickBall(Vector3 direction)
    {
        rb.velocity = direction.normalized * kickForce;
    }

    private void LimitSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        rb.velocity = Vector3.zero;
    }
}
