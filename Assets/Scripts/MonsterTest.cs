using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    const int _MAX = 15;
    public float Mspeed = 1.0f;
    private int monsterHeart = 1;

    private Vector3 dir;
    public GameObject target;
    private int enemy_hp = 100;
    //��������Ʈ �Ŵ��� ���� �и��ϱ�
    private GameObject waypointGO;
    private GameObject[] waypoints = new GameObject[_MAX];
    private int waypointNum = 0;
    private void Start()
    {
        waypointGO = GameObject.Find("Waypoints");
        
        //��� Ž��
        foreach (Transform child in waypointGO.transform) {
            waypoints[waypointNum] = child.gameObject;
            waypointNum++;
        }
        //Debug.Log("��� ��� Ž�� �Ϸ�");
        gameObject.transform.position = waypoints[0].transform.position; //�ʱ� ��ġ ����
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
            //Debug.Log("����!");
            SoundManager.instance.createSoundEffects("EnemyDead", 0.7f);
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
            //Debug.Log("�ƾ�!");
        }
        if (other.tag == "Waypoints" && other.name == target.name) {
            waypointNum++;
            if (waypoints[waypointNum] == null)
            {
                SoundManager.instance.createSoundEffects("gong-played1", 0.3f);
                MapManager.instance.setHeart(monsterHeart);
                Destroy(gameObject);
            }
            target = waypoints[waypointNum];
        }
    }
}
