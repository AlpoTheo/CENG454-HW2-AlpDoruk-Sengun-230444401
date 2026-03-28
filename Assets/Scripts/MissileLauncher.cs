// MissileLauncher.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Alp Doruk Sengun | Student ID: 230444401
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        // spawn the missile at the launch point
        activeMissile = Instantiate(missilePrefab, launchPoint.position, Quaternion.identity);
        activeMissile.tag = "Missile";

        // give the missile its target so it knows what to chase
        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        homing.SetTarget(target);

        // play launch sound
        if (launchAudioSource != null)
            launchAudioSource.Play();

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}
