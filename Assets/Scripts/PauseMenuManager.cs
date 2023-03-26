using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    // Update is called once per frame
    void Update()
    {

    }

    public void restartButton()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void continueButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void backToMainButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
