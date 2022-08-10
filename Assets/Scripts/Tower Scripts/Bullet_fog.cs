using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_fog : Bullet
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            MonsterTest mon = other.GetComponent<MonsterTest>();
            mon.setEnemyHP(dam);
            Destroy(gameObject);
        }
    }
}
