using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    public GameObject characterPrefab;
    private GameObject character;
    private AudioSource audioSource;
    private GameManager gameManager;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(character == null)
        {
            CharacterStat characterStat = characterPrefab.GetComponent<CharacterStat>();
            if (characterStat.canCreate(gameManager.seed))
            {
                character = (GameObject)Instantiate(characterPrefab, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(audioSource.clip);
                gameManager.seed -= character.GetComponent<CharacterStat>().cost;
                gameManager.updateText();
            }

            
        }

    }
}


