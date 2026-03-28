// LandingTrigger.cs
// CENG 454 - HW2 Midterm
// Alp Doruk Sengun - 230444401
using UnityEngine;

public class LandingTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource landingAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (landingAudioSource != null)
            landingAudioSource.Play();

        examManager.TryLanding();
    }
}
