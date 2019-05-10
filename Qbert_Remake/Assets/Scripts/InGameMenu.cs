using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public Button mainMenu;
    public Button Back;

    void Start ()
    {
        this.gameObject.SetActive(false);
        mainMenu.onClick.AddListener(QuitGame);
        Back.onClick.AddListener(ResumeGame);
    }

    private void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
