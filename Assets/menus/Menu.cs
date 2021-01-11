using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour, DefeatListener
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUi;
    public GameObject defeatMenuUi;
    public TMPro.TextMeshProUGUI ipText;
    public TextMeshProUGUI score;

    private void Start()
    {
        var ip = Utils.GetLocalIPAddress();
        if (ip != null)
            ipText.text = "Your ip addres: " + ip;
        else
            ipText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (defeatMenuUi.active == true)
                return;
            if(isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    public void onDefeat()
    {
        defeatMenuUi.SetActive(true);
        score.text = "Your score " + Stat.killCount.ToString();
    }


    private void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Restart()
    {
        Stat.killCount = 0;
        SceneManager.UnloadSceneAsync("GameScene");
        isGamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        Stat.killCount = 0;
        SceneManager.UnloadSceneAsync("GameScene");
        isGamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Stat.killCount = 0;
        Application.Quit();
    }
}
