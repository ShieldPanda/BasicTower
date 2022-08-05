using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_multishot : Bullet
{
    private void Start()
    {
        Bspeed = 6.0f;
        SoundManager.instance.createSoundEffects("TowerFire3", 0.5f);
        Destroy(gameObject, spantime);
        dir = (target.transform.position - this.transform.position).normalized;
        
        Debug.Log(dir.ToString());
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
