using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Leaderboards : MonoBehaviour
{
    public Text[] texts;
    public Button Back;
    public DataHolder data;


    void Start()
    {
        Back.onClick.AddListener(mainmenu);
        SetupTexts();
    }

    private void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void SetupTexts()
    {
        for (int j = 0; j < 10; j++)//sets up texts with data from DataHolder
        {
            if(data.highScores[j] != 0)
            {
                texts[j].text = data.initials[j].ToString() + ": " + data.highScores[j];
            }
            else
            {
                break;
            }
        }
    }
}
