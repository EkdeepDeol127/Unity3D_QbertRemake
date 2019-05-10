using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Button Leaderboard;
    public Button Play;
    public Button Exit;
    public AudioSource source;

    void Start ()
    {
        Leaderboard.onClick.AddListener(LeaderboardScene);
        Play.onClick.AddListener(StartGame);
        Exit.onClick.AddListener(QuitGame);
        source.Play();
    }

    private void LeaderboardScene()
    {
        source.Stop();
        SceneManager.LoadScene("Leaderboard");
    }

    private void QuitGame()
    {
        source.Stop();
        Debug.Log("Quitting");
        Application.Quit();
    }

    private void StartGame()
    {
        source.Stop();
        SceneManager.LoadScene("Main");
    }
}
