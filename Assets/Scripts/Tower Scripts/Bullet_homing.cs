using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet을 상속받는 추적탄
public class Bullet_homing : Bullet
{
    void Start()
    {
        ad.Play();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector2 dir = (target.transform.position - this.transform.position).normalized;
        float vx = dir.x * speed;
        float vy = dir.y * speed;
        rb.velocity = new Vector2(vx, vy);
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
