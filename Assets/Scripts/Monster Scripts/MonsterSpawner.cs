using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public enum EnemyType
    {
        Enemy_Test //������ ���� (���ð���)
    }

    private float spawnTime = 0f;
    private float spawnTimeLimit = 0.3f; //���Ͱ� �����Ǵ� ����
    public int enemyLimit; // ������ ������ ��
    public int enemyNumber = 0;
    public EnemyType Etype;
    private GameObject enemy; // ������ ����
    private GameObject[] enemy_array = new GameObject[30];

    private void Start()
    {
        enemy = Resources.Load<GameObject>($"Prefabs/{Etype.ToString()}");
    }

    private void FixedUpdate()
    {
        spawnTime += Time.deltaTime;

        if (enemyNumber >= enemyLimit) { } //���̻� ������ ������ ���� ���� ��� �Ѿ.
        else
        {
            if (spawnTime >= spawnTimeLimit) //���� ������ �Ǿ��� ��� ���͸� �����ϰ�, enemyLimit�� ���� ����.
            {

                enemy_array[enemyNumber] = Instantiate(enemy) as GameObject;
                enemy_array[enemyNumber].name = "���� " + enemyNumber.ToString();

                spawnTime = 0f;
                enemyNumber++;
            }
        }
    }
}
