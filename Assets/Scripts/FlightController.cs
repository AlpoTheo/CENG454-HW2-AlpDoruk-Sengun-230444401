// FlightController.cs
// CENG 454 - HW1 Baseline (imported into HW2)
// Alp Doruk Sengun - 230444401
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float pitchSpeed = 45f;
    public float yawSpeed = 45f;
    public float rollSpeed = 45f;
    public float thrustSpeed = 50f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    void HandleRotation()
    {
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, pitch);

        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll = rollSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) roll = -rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, roll);
    }

    void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
    }
}
