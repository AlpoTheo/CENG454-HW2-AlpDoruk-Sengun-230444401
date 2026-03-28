// TakeoffTrigger.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Alp Doruk Sengun | Student ID: 230444401
using UnityEngine;

public class TakeoffTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    // player leaves the takeoff area = they took off
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.SetTakenOff();
        }
    }
}
