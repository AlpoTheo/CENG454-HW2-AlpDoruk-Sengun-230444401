// AircraftThreatHandler.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Alp Doruk Sengun | Student ID: 230444401
using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if it was a missile that hit us
        if (!other.CompareTag("Missile")) return;

        // play hit sound
        if (hitAudioSource != null)
            hitAudioSource.Play();

        // tell the manager we got hit
        examManager.OnMissileHit();

        // destroy the missile
        Destroy(other.gameObject);

        // reset the aircraft back to the spawn point
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
