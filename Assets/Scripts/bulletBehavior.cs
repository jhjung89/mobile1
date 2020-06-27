using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{

    public float speed = 10.0f;
    public GameObject character;
    public int damage;
    public void setDamage(int input)
    {
        damage = input;
    }
    void Start()
    {
        Destroy(gameObject, 3.0f);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(damage);
        }
        
    }
}
