using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameUI;
    public GameObject pauseMenu;

    public void OnGoToMenu()
    {
        menuPanel.SetActive(true);
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void OnLeaveMenu()
    {
        menuPanel.SetActive(false);
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void OnPause()
    {
        menuPanel.SetActive(false);
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
