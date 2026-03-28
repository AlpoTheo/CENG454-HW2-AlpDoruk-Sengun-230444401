// FlightExamManager.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Alp Doruk Sengun | Student ID: 230444401
using UnityEngine;
using TMPro;
using System.Collections;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private float endDelay = 3f;

    // mission state flags
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    void Start()
    {
        Time.timeScale = 1f; // make sure game runs normally on start
        statusText.text = "";
        missionText.text = "Take off to begin the mission";
    }

    public void SetTakenOff()
    {
        if (hasTakenOff) return; // only trigger once
        hasTakenOff = true;
        missionText.text = "Fly toward the danger zone";
    }

    public void EnterDangerZone()
    {
        // show the warning right away, dont wait for missile
        statusText.text = "Entered a Dangerous Zone!";
        statusText.color = Color.red;
        missionText.text = "Escape the danger zone!";
    }

    public void ExitDangerZone()
    {
        statusText.text = ""; // clear the warning
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
        // dont allow landing if we havent taken off or cleared the threat yet
        if (!hasTakenOff || !threatCleared)
        {
            missionText.text = "Complete the danger zone first!";
            return;
        }

        if (missionComplete) return; // prevent double trigger

        missionComplete = true;
        statusText.text = "Mission Complete!";
        statusText.color = Color.green;
        missionText.text = "Safe landing. Well done!";

        // freeze the game after a short delay so player can read the message
        StartCoroutine(FreezeAfterDelay());
    }

    private IEnumerator FreezeAfterDelay()
    {
        yield return new WaitForSeconds(endDelay);
        Time.timeScale = 0f; // pause the game
    }

    public bool HasTakenOff() { return hasTakenOff; }
    public bool IsThreatCleared() { return threatCleared; }
    public bool IsMissionComplete() { return missionComplete; }
}
