// DangerZoneController.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Alp Doruk Sengun | Student ID: 230444401
using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private GameObject activeMissile;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // tell the manager we entered the zone
        examManager.EnterDangerZone();

        // start the 5 second missile countdown
        activeCountdown = StartCoroutine(MissileCountdown(other.transform));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // cancel the countdown if missile hasnt launched yet
        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        // destroy missile if one is active
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }

        // tell the manager the threat is cleared
        examManager.ExitDangerZone();
    }

    // waits 5 seconds then tells the launcher to fire
    private IEnumerator MissileCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        activeMissile = missileLauncher.Launch(target);
        activeCountdown = null;
    }
}
