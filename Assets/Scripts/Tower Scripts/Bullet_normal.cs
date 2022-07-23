using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet�� ��ӹ޴� �⺻���� ź
public class Bullet_normal : Bullet
{
    
    // Start is called before the first frame update
    void Start()
    {
        Bspeed = 8.0f;
        sM.createSoundEffects("TowerFire");
        Destroy(gameObject, spantime);
        dir = (target.transform.position - this.transform.position).normalized;
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(dir*Time.deltaTime*Bspeed);
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
