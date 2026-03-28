// DangerZoneController.cs
// CENG 454 - HW2 Midterm
// Alp Doruk Sengun - 230444401
using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 2f;

    private Coroutine activeCountdown;
    private GameObject activeMissile;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.EnterDangerZone();

        // start countdown, missile fires after delay
        activeCountdown = StartCoroutine(MissileCountdown(other.transform));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // stop countdown if still running
        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        // destroy missile if it exists
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }

        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        activeMissile = missileLauncher.Launch(target);
        activeCountdown = null;
    }
}
