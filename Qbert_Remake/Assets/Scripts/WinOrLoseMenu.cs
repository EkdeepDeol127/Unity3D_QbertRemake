using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinOrLoseMenu : MonoBehaviour {

    public Button mainMenu;
    public Button leaderBoard;
    public Text response;
    public DataHolder data;
    public InputField initials;
    private int score;
    private string playerName;

    void Start()
    {
        initials.text = "";
        score = 10;
        mainMenu.onClick.AddListener(MainMenu);
        leaderBoard.onClick.AddListener(leader);
        if (data.checkHighScore(score))
        {
            response.text = "You beat a high score! \n Enter your initials";
            initials.enabled = true;
        }
        else
        {
            response.text = "You did not beat a high score.";
            initials.enabled = false;
        }
    }

    private void MainMenu()
    {
        data.NewHighScore(playerName, score);
        SceneManager.LoadScene("MainMenu");
    }

    private void leader()
    {
        data.NewHighScore(playerName, score);
        SceneManager.LoadScene("LeaderBoard");
    }

    public void addScore(int amount)
    {
        score = amount;
    }

    public void editInitials(string newText)
    {
        playerName = newText;
    }
}
