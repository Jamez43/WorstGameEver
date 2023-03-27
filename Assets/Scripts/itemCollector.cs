using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{

    private float cherries = 0;
    private float totalCherries;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        totalCherries = GameObject.FindGameObjectsWithTag("Cherry").Length;
        PlayerInfo.tempJs[SceneManager.GetActiveScene().buildIndex - 1] = 0;
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            int percent = (int)((cherries / totalCherries) * 100);
            cherriesText.text = "Jordans: " + cherries + "\nPercent: " + percent + "%";
            PlayerInfo.tempJs[SceneManager.GetActiveScene().buildIndex - 1] = percent;
        }
    }
}
