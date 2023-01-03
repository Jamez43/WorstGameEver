using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{

    [SerializeField] public string level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level" + level);

    }
}
