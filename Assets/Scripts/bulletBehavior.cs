using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public GameObject character;
    public BulletStat bulletStat { get; set; }
    
    public bulletBehavior()
    {
        bulletStat = new BulletStat(0, 0); // Start 함수전에 초기화하도록 하자
    }
    
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(bulletStat.damage);
        }
        
    }
}
