using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject GameOverScreen;
    [SerializeField]
    GameObject WinnerScreen, GameGuide;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
     public void ShowWinScreen()
    {
        WinnerScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowGameGuide(bool isOpen)
    {
        if (isOpen)
        {
            GameGuide.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            GameGuide.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void GoBackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }


}
