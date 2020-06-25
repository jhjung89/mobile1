using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

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

    private AudioSource audioSource;
    
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
        audioSource = roundStartText.GetComponent<AudioSource>();
        updateText();
        nextRound();
    }

    void Update()
    {
        
    }
}
