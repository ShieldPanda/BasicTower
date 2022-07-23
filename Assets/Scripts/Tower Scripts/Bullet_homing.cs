using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet을 상속받는 추적탄
public class Bullet_homing : Bullet
{
    private Vector3 dir2;
    void Start()
    {
        sM.createSoundEffects("TowerFire2");
        Destroy(gameObject, spantime);
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            dir = dir2;
        }
        else
        {
            dir = (target.transform.position - this.transform.position).normalized;
        }
        dir2 = dir;
        gameObject.transform.Translate(dir* Time.deltaTime * Bspeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            MonsterTest mon = other.GetComponent<MonsterTest>();
            mon.setEnemyHP(dam);
            Debug.Log($"{dam}의 데미지를 주었다!");
            Destroy(gameObject);
        }
    }
}
