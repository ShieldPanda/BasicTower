using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip fireSound;
    protected AudioSource ad;
    public GameObject target = null;
    protected float spantime = 4.0f;
    protected int dam = 20;
    protected float Bspeed = 2.0f;
    protected Vector3 dir;
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            MonsterTest mon = other.GetComponent<MonsterTest>();
            mon.setEnemyHP(dam);
            Destroy(gameObject);
        }
    }
}
