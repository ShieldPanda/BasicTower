using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private float spawnTime = 0f;
    private float spawnTimeLimit = 2.0f; //���Ͱ� �����Ǵ� ����
    private GameObject enemy; // ������ ����
    public int enemyLimit = 3; // ������ ������ ��
    public enum EnemyType { Enemy_Test } //������ ���� (���ð���)
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
