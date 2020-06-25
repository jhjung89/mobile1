﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    private MonsterStat monsterStat;
    private Animator animator;
    private bool attacking = false;

    private float lastAttackTime;
    private CharacterStat targetStat;


    void Start()
    {
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(audiosource.clip);
        animator = gameObject.GetComponent<Animator>();
        monsterStat = gameObject.GetComponent<MonsterStat>();
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * 1 * Time.deltaTime);

        if (attacking)
        {
            transform.Translate(Vector2.right * monsterStat.speed * Time.deltaTime);
        }
        if (targetStat != null && targetStat.hp <= 0)
        {
            targetStat = null;
            attacking = false;
            animator.SetTrigger("Walk");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Fence")
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Character")
        {
            attacking = true;
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
            targetStat = other.gameObject.GetComponent<CharacterStat>();
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) // 반복적으로 충동이 발생할 경우 불러오는 함수
    {
        if(other.gameObject.tag == "Character")
        {
            if(Time.time - lastAttackTime > monsterStat.coolTime)
            {
                int hp = other.gameObject.GetComponent<CharacterStat>().attacked(monsterStat.damage);
                if(hp<=0)
                {
                    attacking = false;
                    animator.SetTrigger("Walk");
                }
                lastAttackTime = Time.time;
            }
        }
    }
}
