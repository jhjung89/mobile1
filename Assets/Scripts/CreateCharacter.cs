using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateCharacter : MonoBehaviour
{
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;
    private GameObject characterPrefab;
    private GameObject character;
    private AudioSource audioSource;
    private CharacterStat characterStat;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject(-1) == true) return; 
        if (EventSystem.current.IsPointerOverGameObject(0) == true) return;
        // 만약 UI가 열려 있는 상황에서는 터치를 막는다. 
        // IsPointerOverGameObject()에 아무 값을 넣지 않을 경우 마우스의 대한 처리만 한다. 마우스 : -1, 모바일 0 이상
        if (GameManager.instance.nowSelect == 1)
        {
            characterPrefab = characterPrefab1;
            characterStat = characterPrefab.GetComponent<CharacterStat>();
        }

        else if (GameManager.instance.nowSelect == 2)
        {
            characterPrefab = characterPrefab2;
            characterStat = characterPrefab.GetComponent<CharacterStat>();
        }

        if (character == null)
        {
            CharacterStat characterStat = characterPrefab.GetComponent<CharacterStat>();
            if (characterStat.canCreate(GameManager.instance.seed))
            {
                character = (GameObject)Instantiate(characterPrefab, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(audioSource.clip);
                GameManager.instance.seed -= character.GetComponent<CharacterStat>().cost;
                GameManager.instance.updateText();
            }

            
        }

    }
}


