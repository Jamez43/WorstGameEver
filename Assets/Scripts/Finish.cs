using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            GameObject.Find("Timer").SendMessage("Finish");
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        PlayerInfo.levelsCompleted[SceneManager.GetActiveScene().buildIndex - 1] = true;
        //print out levels completed
        for (int i = 0; i < PlayerInfo.levelsCompleted.Length; i++)
        {
            Debug.Log("Level " + (i + 1) + ": " + PlayerInfo.levelsCompleted[i]);
        }
        SceneManager.LoadScene(0);
    }

}