// MissileLauncher.cs
// CENG 454 - HW2 Midterm
// Alp Doruk Sengun - 230444401
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        activeMissile = Instantiate(missilePrefab, launchPoint.position, Quaternion.identity);
        activeMissile.tag = "Missile";

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        homing.SetTarget(target);

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
