using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet�� ��ӹ޴� ����ź
public class Bullet_homing : Bullet
{
    void Start()
    {
        sM.createSoundEffects("TowerFire2");
        Destroy(gameObject, spantime);
    }

    void FixedUpdate()
    {   
        dir = (target.transform.position - this.transform.position).normalized;
        gameObject.transform.Translate(dir* Time.deltaTime * Bspeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            MonsterTest mon = other.GetComponent<MonsterTest>();
            mon.setEnemyHP(dam);
            Debug.Log($"{dam}�� �������� �־���!");
            Destroy(gameObject);
        }
    }
}
