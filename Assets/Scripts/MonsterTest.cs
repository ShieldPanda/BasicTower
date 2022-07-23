using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    const int _MAX = 15;
    public float Mspeed = 1.0f;
    private Rigidbody2D rb;
    private GameObject sManager;
    private SoundManager sM;
    private Vector3 dir;
    public GameObject target;
    // Update is called once per frame

    private int enemy_hp = 100;
    private GameObject waypointGO;
    private GameObject[] waypoints = new GameObject[_MAX];
    private int waypointNum = 0;
    private void Start()
    {
        sManager = GameObject.Find("@SoundManager");
        sM = sManager.GetComponent<SoundManager>();

        waypointGO = GameObject.Find("Waypoints");
        
        //경로 탐색
        foreach (Transform child in waypointGO.transform) {
            waypoints[waypointNum] = child.gameObject;
            waypointNum++;
        }
        Debug.Log("모든 경로 탐색 완료");
        gameObject.transform.position = waypoints[0].transform.position; //초기 위치 설정
        waypointNum = 1;
        target = waypoints[waypointNum];
        
    }
    void FixedUpdate()
    {
        dir = (target.transform.position - this.transform.position).normalized;
        gameObject.transform.Translate(dir * Time.deltaTime * Mspeed);

        //if (Input.GetKey(KeyCode.A))
        //{
        //    gameObject.transform.position += Vector3.left * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D)) {
        //    gameObject.transform.position += Vector3.right * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    gameObject.transform.position += Vector3.up * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    gameObject.transform.position += Vector3.down * Time.deltaTime;
        //}

        if (enemy_hp <= 0) {
            
            Debug.Log("으악!");
            sM.createSoundEffects("EnemyDead");
            Destroy(gameObject);
        }

        if (target == null) {
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
        Debug.Log("Hit Detected");
        if (other.tag == "Bullet")
        {
            Debug.Log("아야!");
        }
        if (other.tag == "Waypoints" && other.name == target.name) {
            Debug.Log($"{waypointNum}번 포인트 도착");
            waypointNum++;
            target = waypoints[waypointNum];
        }
    }
}
