using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip fireSound;
    private GameObject soundManager;
    protected AudioSource ad;
    public GameObject target = null;
    protected float spantime = 4.0f;
    protected int dam = 20;
    protected float speed = 2.0f;
    protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        soundManager = GameObject.Find("SoundEffect");
        ad = soundManager.GetComponent<AudioSource>();
        ad.clip = fireSound;
        ad.playOnAwake = false;
        Destroy(gameObject, spantime);
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
