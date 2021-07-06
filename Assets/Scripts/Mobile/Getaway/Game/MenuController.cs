using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject inGameUI;
    public GameObject lossScreen;

    public GameObject cam;
    public Transform camOriginal;
    

    public void OnGoToMenu()
    {
        menuPanel.SetActive(true);
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        cam.transform.position = camOriginal.position;
        cam.transform.forward = camOriginal.forward;
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
        pauseMenu.SetActive(true);
        GameController.Instance.OnPause();
    }
    public void OnLose()
    {
        gameUI.SetActive(true);
        lossScreen.SetActive(true);
        inGameUI.SetActive(false);
        GameController.Instance.OnLoss();

    }
    public void OnUnpause()
    {
        inGameUI.SetActive(true);
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
        GameController.Instance.OnPause();
    }

    public void OnAppQuit()
    {
        Application.Quit();
    }

    float timer = 0;
    float timeToWait = 11.5f;
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



    }
}
