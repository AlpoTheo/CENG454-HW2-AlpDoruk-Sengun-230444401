// FlightExamManager.cs
// CENG 454 - HW2 Midterm
// Alp Doruk Sengun - 230444401
using UnityEngine;
using TMPro;
using System.Collections;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private float endDelay = 3f;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    void Start()
    {
        Time.timeScale = 1f;
        statusText.text = "";
        missionText.text = "Take off to begin the mission";
    }

    public void SetTakenOff()
    {
        if (hasTakenOff) return;
        hasTakenOff = true;
        missionText.text = "Fly toward the danger zone";
    }

    public void EnterDangerZone()
    {
        statusText.text = "Entered a Dangerous Zone!";
        statusText.color = Color.red;
        missionText.text = "Escape the danger zone!";
    }

    public void ExitDangerZone()
    {
        statusText.text = "";
        threatCleared = true;
        missionText.text = "Threat cleared! Find the landing strip";
    }

    public void OnMissileHit()
    {
        statusText.text = "HIT! Mission Failed";
        statusText.color = Color.red;
        missionText.text = "Restarting...";
    }

    public void TryLanding()
    {
        if (!hasTakenOff || !threatCleared)
        {
            missionText.text = "Complete the danger zone first!";
            return;
        }

        if (missionComplete) return;

        missionComplete = true;
        statusText.text = "Mission Complete!";
        statusText.color = Color.green;
        missionText.text = "Safe landing. Well done!";

        StartCoroutine(FreezeAfterDelay());
    }

    // wait a bit then freeze the game
    private IEnumerator FreezeAfterDelay()
    {
        yield return new WaitForSeconds(endDelay);
        Time.timeScale = 0f;
    }

    public bool HasTakenOff() { return hasTakenOff; }
    public bool IsThreatCleared() { return threatCleared; }
    public bool IsMissionComplete() { return missionComplete; }
}
