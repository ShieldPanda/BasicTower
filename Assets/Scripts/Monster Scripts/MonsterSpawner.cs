using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public enum EnemyType
    {
        Enemy_Test //스폰할 몬스터 (선택가능)
    }

    private float spawnTime = 0f;
    private float spawnTimeLimit = 0.3f; //몬스터가 스폰되는 간격
    public int enemyLimit; // 스폰될 몬스터의 수
    public int enemyNumber = 0;
    public EnemyType Etype;
    private GameObject enemy; // 스폰될 몬스터
    private GameObject[] enemy_array = new GameObject[30];

    private void Start()
    {
        enemy = Resources.Load<GameObject>($"Prefabs/{Etype.ToString()}");
    }

    private void FixedUpdate()
    {
        spawnTime += Time.deltaTime;

        if (enemyNumber >= enemyLimit) { } //더이상 스폰할 몬스터의 수가 없을 경우 넘어감.
        else
        {
            if (spawnTime >= spawnTimeLimit) //스폰 간격이 되었을 경우 몬스터를 스폰하고, enemyLimit의 수를 줄임.
            {

                enemy_array[enemyNumber] = Instantiate(enemy) as GameObject;
                enemy_array[enemyNumber].name = "몬스터 " + enemyNumber.ToString();

                spawnTime = 0f;
                enemyNumber++;
            }
        }
    }
}
