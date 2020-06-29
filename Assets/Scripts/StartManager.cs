﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
