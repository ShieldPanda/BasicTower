using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    private int monsterHeart = 1;
    private int enemy_hp = 100;
    public float Mspeed = 1.0f;
    private int nextWaypoint = 0;
    private Vector3 dir;
    public GameObject target;

    private void Start()
    {
        gameObject.transform.position = WaypointManager.instance.getStartPoint().transform.position;
        target = WaypointManager.instance.getNextPoint(nextWaypoint);
    }

    private void FixedUpdate()
    {
        dir = (target.transform.position - this.transform.position).normalized;
        gameObject.transform.Translate(dir * Time.deltaTime * Mspeed);

        if (enemy_hp <= 0) {
            SoundManager.instance.createSoundEffects("EnemyDead", 0.7f);
            Destroy(gameObject);
        }
    }

    // EnemyHP 프로퍼티
    public int EnemyHP
    {
        get { return enemy_hp; }
        //set { enemy_hp -= value; }
    }

    public int getEnemyHP() {
        return enemy_hp;
    }

    public void setEnemyHP(int damage, int heal = 0) {
        enemy_hp = enemy_hp + heal - damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Waypoints" && other.name == target.name) {

            nextWaypoint++;

            if (WaypointManager.instance.getNextPoint(nextWaypoint) == null)
            {
                SoundManager.instance.createSoundEffects("EnemyPassed", 0.3f);
                MapManager.instance.setHeart(monsterHeart);
                Destroy(gameObject);
            }

            target = WaypointManager.instance.getNextPoint(nextWaypoint);
        }
    }
}
