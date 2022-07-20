using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    int enemy_hp = 100;
    private GameObject soundManager;
    protected AudioSource ad;
    public AudioClip deathSound;
    // Update is called once per frame
    private void Start()
    {
        soundManager = GameObject.Find("SoundEffect");
        ad = soundManager.GetComponent<AudioSource>();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            gameObject.transform.position += Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime;
        }

        if (enemy_hp <= 0) {
            
            Debug.Log("À¸¾Ç!");
            ad.clip = deathSound;
            ad.Play();
            Destroy(gameObject);
        }
    }

    public int getEnemyHP() {
        return enemy_hp;
    }

    public void setEnemyHP(int damage, int heal = 0) {
        enemy_hp = enemy_hp + heal - damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Hit Detected");
        }
    }
}
