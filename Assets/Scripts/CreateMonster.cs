using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{


    public List<GameObject> respawnSpotList;

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;

    private float lastSpawnTime;
    private int spawnCount = 0;

    void Start()
    {
        //GameManager.instance = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        // 싱글톤 기법에 비해 리소스를 많이 잡아먹는다. 추가로, GameManager라는 파일명을 가진게 많다면 오류가 발생할 수 있다.

        monsterPrefab = monster1Prefab;
        lastSpawnTime = Time.time; // Time.time 현재 시간을 가져옮


    }

    void Update()
    {
        if(GameManager.instance.round <= GameManager.instance.totalRound)
        {
            float timeGap = Time.time - lastSpawnTime;
            if((spawnCount == 0 && timeGap > GameManager.instance.roundReadyTime // 새 라운드 시작
                || timeGap > GameManager.instance.spawnTime)
                && spawnCount < GameManager.instance.spawnNumber)
            {
                lastSpawnTime = Time.time; // 다시 리스폰이 이뤄진거라 현재 시간으로 다시 초기화
                int index = Random.Range(0, 4); // 시작 숫자 ~ 끝숫자-1 사이의 랜덤한 값이 생성된다.
                GameObject respawnSpot = respawnSpotList[index];
                
                Instantiate(monsterPrefab, respawnSpot.transform.position, Quaternion.identity);
                spawnCount += 1;
            }
            if(spawnCount == GameManager.instance.spawnNumber &&
                GameObject.FindGameObjectWithTag("Monster") == null)
            {
                if(GameManager.instance.totalRound == GameManager.instance.round)
                {
                    GameManager.instance.gameClear();
                    GameManager.instance.round += 1; // 이건 왜 해주는가
                    return;
                }
                GameManager.instance.clearRound();
                spawnCount = 0;
                lastSpawnTime = Time.time;

                if( GameManager.instance.round == 4)
                {
                    monsterPrefab = monster2Prefab;
                    GameManager.instance.spawnTime = 2.0f;
                    GameManager.instance.spawnNumber = 10;
                }
            }
        }
        
    }
}
