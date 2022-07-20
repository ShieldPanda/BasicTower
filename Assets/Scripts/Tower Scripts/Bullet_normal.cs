using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet을 상속받는 기본적인 탄
public class Bullet_normal : Bullet
{
    float vx, vy;
    // Start is called before the first frame update
    void Start()
    {
        ad.Play();
        speed = 3.0f;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Vector2 dir = (target.transform.position - this.transform.position).normalized;
        vx = dir.x * speed;
        vy = dir.y * speed;
    }

    void FixedUpdate()
    {
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
