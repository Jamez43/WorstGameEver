using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{

    [SerializeField] public int level;

    [SerializeField] private Text timeText;

    // Start is called before the first frame update
    private void Start()
    {
        if(PlayerInfo.recordTimes[level-1] != null)
        timeText.text = PlayerInfo.recordTimes[level - 1] + "\nJordans: " + PlayerInfo.jordanPercent[level-1] + "%";
    }

    // Update is called once per frame
    public void LevelSelect()
    {
        //can only play if level before is completed
        if (level == 1 || PlayerInfo.levelsCompleted[level - 2] == true)
        {
            SceneManager.LoadScene("Level" + level.ToString());
        }
    }
}
