﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }
    private void Awake() // MonoBehavior를 상속 받을 경우에는 Awake()함수를 사용하는게 좋다.
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }


    public Text seedText;
    public Text roundText;
    public Text roundStartText;

    public int round = 0;
    public int seed = 1000;

    public int roundReadyTime = 5; //대기시간
    public int totalRound = 3; //
    public int reward = 500; // 라운드 클리어 시 
    public float spawnTime = 2.5f;
    public int spawnNumber = 5;
    private AudioSource audioSource;

    public int nowSelect;
    public Image select1;
    public Image select2;

    public Text clearText;
    public Text lifeText;

    public int life = 10;
    public Text loseText;
    public GameObject respawnSpot;

    public int decreaseLife()
    {
        if(life >= 1)
        {
            life--;
            lifeText.text = ": " + life;
            if(life == 0)
            {
                loseText.enabled = true;
                respawnSpot.GetComponent<CreateMonster>().enabled = false;
            }
        }
        return life;
    }
    public void gameClear()
    {
        clearText.enabled = true;
    }

    public void select(int number)
    {
        if( number == 1)
        {
            nowSelect = 1;
            select1.GetComponent<Image>().color = Color.gray;
            select2.GetComponent<Image>().color = Color.white;
        }
        else if (number == 2)
        {
            nowSelect = 2;
            select1.GetComponent<Image>().color = Color.white;
            select2.GetComponent<Image>().color = Color.gray;
        }
    }

    public void clearRound()
    {
        if(round < totalRound)
        {
            nextRound();
            seed += reward;
            updateText();
            spawnTime -= 0.2f;
            spawnNumber += 3;
            reward += 150;
        }
    }

    
    
    public void nextRound()
    {
        round = round + 1;
        if(round == 1)
        {
            roundText.text = "ROUND 0" + round;
            roundStartText.text = "ROUND 0" + round;
        }

        else if(round < 10)
        {
            roundText.text = "ROUND 0" + round;
            roundStartText.text = "ROUND 0" + round;
            roundStartText.GetComponent<Animator>().SetTrigger("Round Start");
        }
        else
        {
            roundText.text = "ROUND " + round;
            roundStartText.text = "ROUND " + round;
            roundStartText.GetComponent<Animator>().SetTrigger("Round Start");
        }
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void updateText()
    {
        seedText.text = "씨앗: " + seed;
    }

    void Start()
    {
        Screen.SetResolution(1920, 1200, true);
        clearText.enabled = false;
        loseText.enabled = false;
        select(1);
        audioSource = roundStartText.GetComponent<AudioSource>();
        updateText();
        nextRound();
        lifeText.text = life.ToString();
    }

    void Update()
    {
        
    }
}
