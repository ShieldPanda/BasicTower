using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    
    public float Mspeed = 1.0f;
    private int monsterHeart = 1;

    private Vector3 dir;
    public GameObject target;
    private int enemy_hp = 100;
    private int nextWaypoint = 0;

    private void Start()
    {
        gameObject.transform.position = WaypointManager.instance.getStartPoint().transform.position;
        target = WaypointManager.instance.getNextPoint(nextWaypoint);
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
            //Debug.Log("À¸¾Ç!");
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
            //Debug.Log("¾Æ¾ß!");
        }
        if (other.tag == "Waypoints" && other.name == target.name) {
            nextWaypoint++;
            if (WaypointManager.instance.getNextPoint(nextWaypoint) == null)
            {
                SoundManager.instance.createSoundEffects("gong-played1", 0.3f);
                MapManager.instance.setHeart(monsterHeart);
                Destroy(gameObject);
            }
            target = WaypointManager.instance.getNextPoint(nextWaypoint);
        }
    }
}
