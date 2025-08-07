using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CrabStuff;

public class PausePanel : MonoBehaviour
{
    public Button settingsButton;
    public Button mainMenuButton;
    public Button continueButton;


    void Start()
    {
        settingsButton.onClick.AddListener(Settings);
        mainMenuButton.onClick.AddListener(MainMenu);
        continueButton.onClick.AddListener(ClosePause);
    }

    void Settings()
    {
        AudioManager.Instance.PlaySound("Button");
        MainUI.Instance.settPanel.SetActive(true);
    }

    void MainMenu()
    {
        AudioManager.Instance.PlaySound("Button");
        Loader.ToMainMenu();
    }

    void ClosePause()
    {
        AudioManager.Instance.PlaySound("Button");
        MainUI.Instance.UnPause();
    }
}
