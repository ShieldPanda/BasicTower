using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum bulletType
    {
        Bullet_normal,
        Bullet_homing

    }

    private float fireTime = 0;
    public float fireTimeLimit = 1.3f;
    public bulletType btype;
    private GameObject bullet = null;
    private GameObject spawner = null;

    private void Start()
    {
        bullet =  Resources.Load<GameObject>($"Prefabs/{btype.ToString()}");
        spawner = transform.Find("tower_bulletSpawner").gameObject;
    }

    private void Update()
    {
        fireTime += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log($"목표 : {other.gameObject.name}");
            if (fireTime >= fireTimeLimit)
            {
                //Debug.Log("발사!");
                bullet.GetComponent<Bullet>().target = other.gameObject;
                Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
                fireTime = 0;
            }
        }
        else return;
    }

}
