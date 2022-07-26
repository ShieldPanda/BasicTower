using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private float spawnTime = 0f;
    private float spawnTimeLimit = 2.0f; //몬스터가 스폰되는 간격
    private GameObject enemy; // 스폰될 몬스터
    public int enemyLimit = 3; // 스폰될 몬스터의 수
    public enum EnemyType { Enemy_Test } //스폰할 몬스터 (선택가능)
    public EnemyType Etype;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Resources.Load<GameObject>($"Prefabs/{Etype.ToString()}");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTime += Time.deltaTime;
        if (enemyLimit <= 0) { } //더이상 스폰할 몬스터의 수가 없을 경우 넘어감.
        else
        {
            if (spawnTime >= spawnTimeLimit) //스폰 간격이 되었을 경우 몬스터를 스폰하고, enemyLimit의 수를 줄임.
            {
                Instantiate(enemy);
                spawnTime = 0f;
                enemyLimit--;
            }
        }
    }
}
