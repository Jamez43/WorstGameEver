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
        Debug.Log("start");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
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
        Debug.Log("complete");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}