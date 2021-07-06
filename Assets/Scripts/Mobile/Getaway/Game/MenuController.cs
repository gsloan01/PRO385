using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameUI;
    public GameObject pauseMenu;

    public GameObject cam;
    

    public void OnGoToMenu()
    {
        menuPanel.SetActive(true);
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        GameController.Instance.OnMenu();
    }
    public void OnLeaveMenu()
    {
        menuPanel.SetActive(false);
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
        cam.GetComponent<Animator>().SetTrigger("GameStart");
        startingGame = true;
    }
    public void OnPause()
    {
        menuPanel.SetActive(false);
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
        GameController.Instance.OnPause();
    }

    public void OnAppQuit()
    {
        Application.Quit();
    }

    float timer = 0;
    float timeToWait = 12;
    bool startingGame = false;
    private void Update()
    {
        if(startingGame)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                cam.SetActive(false);
                GameController.Instance.OnGame();
                timer = 0;
                startingGame = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }

    }
}
