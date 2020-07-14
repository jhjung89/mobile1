using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{

    private GameManager gameManager;

    public List<GameObject> respawnSpotList;

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;

    private float lastSpawnTime;
    private int spawnCount = 0;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        monsterPrefab = monster1Prefab;
        lastSpawnTime = Time.time; // Time.time 현재 시간을 가져옮


    }

    void Update()
    {
        if(gameManager.round <= gameManager.totalRound)
        {
            float timeGap = Time.time - lastSpawnTime;
            if((spawnCount == 0 && timeGap > gameManager.roundReadyTime // 새 라운드 시작
                || timeGap > gameManager.spawnTime)
                && spawnCount < gameManager.spawnNumber)
            {
                lastSpawnTime = Time.time; // 다시 리스폰이 이뤄진거라 현재 시간으로 다시 초기화
                int index = Random.Range(0, 4); // 시작 숫자 ~ 끝숫자-1 사이의 랜덤한 값이 생성된다.
                GameObject respawnSpot = respawnSpotList[index];
                
                Instantiate(monsterPrefab, respawnSpot.transform.position, Quaternion.identity);
                spawnCount += 1;
            }
            if(spawnCount == gameManager.spawnNumber &&
                GameObject.FindGameObjectWithTag("Monster") == null)
            {
                if(gameManager.totalRound == gameManager.round)
                {
                    gameManager.gameClear();
                    gameManager.round += 1; // 이건 왜 해주는가
                    return;
                }
                gameManager.clearRound();
                spawnCount = 0;
                lastSpawnTime = Time.time;

                if( gameManager.round == 4)
                {
                    monsterPrefab = monster2Prefab;
                    gameManager.spawnTime = 2.0f;
                    gameManager.spawnNumber = 10;
                }
            }
        }
        
    }
}
