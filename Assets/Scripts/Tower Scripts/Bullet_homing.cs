using UnityEngine;

//bullet을 상속받는 추적탄
public class Bullet_homing : Bullet
{
    private Vector3 dir2;

    private void Start()
    {
        Bspeed = 4.0f;
        Destroy(gameObject, spantime);
    }

    private void FixedUpdate()
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
