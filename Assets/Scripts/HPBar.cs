using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public GameObject image;
    public GameObject character;
    private CharacterStat characterStat;

    public float max = 100;
    public float current = 100;
    private float scale;
   
    void Start()
    {
        scale = image.transform.localScale.x;
        characterStat = character.GetComponent<CharacterStat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        int maxHp = characterStat.maxHp;
        int hp = characterStat.hp;
        current = (float)hp / (float)maxHp * 100;
        if(current < 0)
        {
            current = 0;
        }
        Vector2 temp = image.transform.localScale;
        temp.x = current / max * scale;
        image.transform.localScale = temp;
    }
}
