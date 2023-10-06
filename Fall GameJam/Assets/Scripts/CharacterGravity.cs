using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravityStrength;

    private Vector3 gravityDirection = new Vector3(0, -1, 0);
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 gravity = gravityDirection.normalized * gravityStrength;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}