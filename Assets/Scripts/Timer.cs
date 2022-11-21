using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private float startTime;
    private bool finished = false;

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
        if(intseconds < 10)
        {
            seconds = "0" + seconds;
        }

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.red;
    }
}