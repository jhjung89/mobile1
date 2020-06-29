using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    bool pause = false;
    public GameObject menuCanvas;
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    void Update()
    {
        
    }

    public void GameReset()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void pauseSwitch()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1; // 유니티 내에서 1의 재생속도로 재생함W
            menuCanvas.SetActive(false);
        }
        else
        {
            pause = true;
            Time.timeScale = 0;// 유니티 플레이를 멈춤
            menuCanvas.SetActive(true);
        }
    }
    public void startMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
