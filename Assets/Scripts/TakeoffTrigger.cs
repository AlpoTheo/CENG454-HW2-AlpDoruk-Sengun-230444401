// TakeoffTrigger.cs
// CENG 454 - HW2 Midterm
// Alp Doruk Sengun - 230444401
using UnityEngine;

public class TakeoffTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    // leaving the takeoff area means we took off
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            examManager.SetTakenOff();
    }
}
