using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public enum EnemyType
    {
        Enemy_Test //������ ���� (���ð���)
    }

    private float spawnTime = 0f;
    private float spawnTimeLimit = 2.0f; //���Ͱ� �����Ǵ� ����
    public int enemyLimit = 3; // ������ ������ ��
    public EnemyType Etype;
    private GameObject enemy; // ������ ����

    private void Start()
    {
        enemy = Resources.Load<GameObject>($"Prefabs/{Etype.ToString()}");
    }

    private void FixedUpdate()
    {
        spawnTime += Time.deltaTime;

        if (enemyLimit <= 0) { } //���̻� ������ ������ ���� ���� ��� �Ѿ.
        else
        {
            if (spawnTime >= spawnTimeLimit) //���� ������ �Ǿ��� ��� ���͸� �����ϰ�, enemyLimit�� ���� ����.
            {
                Instantiate(enemy);
                spawnTime = 0f;
                enemyLimit--;
            }
        }
    }
}
