using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_penetrating : Bullet
{
    private void Start()
    {
        Bspeed = 8.0f;
        Destroy(gameObject, spantime);
        dir = (target.transform.position - this.transform.position).normalized;
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(dir * Time.deltaTime * Bspeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            MonsterTest mon = collision.GetComponent<MonsterTest>();
            mon.setEnemyHP(dam);
            Debug.Log($"{collision.name}ÀÇ Ã¼·Â : {collision.GetComponent<MonsterTest>().EnemyHP}");
        }
    }

}
