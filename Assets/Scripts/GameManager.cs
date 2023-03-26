using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            pauseGame();
        }
    }
    public void pauseGame()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
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
