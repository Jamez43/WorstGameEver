using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private Text timerText;
    private float startTime;
    private bool finished = false;

    private static string endTime;

    // Start is called before the first frame update
    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        float intseconds = t % 60;
        string seconds = (t % 60).ToString("f2");
        if (intseconds < 10)
        {
            seconds = "0" + seconds;
        }

        timerText.text = minutes + ":" + seconds;
        endTime = minutes + ":" + seconds;
    }
    public bool isFaster(string oldTime, string newTime)
    {
        int time = oldTime.CompareTo(newTime);
        if (time < 0) return false;
        return true;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.red;

        if (PlayerInfo.recordTimes[SceneManager.GetActiveScene().buildIndex - 1] == null || isFaster(PlayerInfo.recordTimes[SceneManager.GetActiveScene().buildIndex - 1], endTime))
        {
            PlayerInfo.jordanPercent[SceneManager.GetActiveScene().buildIndex - 1] = PlayerInfo.tempJs[SceneManager.GetActiveScene().buildIndex - 1];
            PlayerInfo.recordTimes[SceneManager.GetActiveScene().buildIndex - 1] = endTime;
            Debug.Log("Temp J's = " + PlayerInfo.tempJs[0]);
            Debug.Log("real J's = " + PlayerInfo.jordanPercent[0]);

        }


        for (int i = 0; i < PlayerInfo.recordTimes.Length; i++)
        {
            Debug.Log("Level " + (i + 1) + ": " + PlayerInfo.recordTimes[i]);
        }
    }

}
