using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float spantime = 4.0f;
    protected int dam = 20;
    protected float Bspeed = 2.0f;
    protected Vector3 dir;
    public AudioClip fireSound;
    protected AudioSource ad;
    public GameObject target = null;

    private void Awake()
    {

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Enemy") {
    //        MonsterTest mon = other.GetComponent<MonsterTest>();
    //        mon.setEnemyHP(dam);
    //        Destroy(gameObject);
    //    }
    //}
}
