// LandingTrigger.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Alp Doruk Sengun | Student ID: 230444401
using UnityEngine;

public class LandingTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource landingAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // play landing sound if we have one
        if (landingAudioSource != null)
            landingAudioSource.Play();

        examManager.TryLanding();
    }
}
