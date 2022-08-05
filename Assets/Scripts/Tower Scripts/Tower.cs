using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum bulletType
    {
        Bullet_normal,
        Bullet_homing,
        Area_circle
    }

    private float fireTime = 0;
    public float fireTimeLimit = 1.3f;
    public bulletType btype;

    private GameObject bullet = null;
    private GameObject spawner = null;
    public bool isMulti = false;

    private int multishotNum = 5;
    private float multishot_angle = 15.0f;

    private void Start()
    {
        bullet = Resources.Load<GameObject>($"Prefabs/{btype.ToString()}");
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
                if (isMulti == true)
                {
                    FireMultipleBullet(bullet, bullet.GetComponent<Bullet>().target);
                }
                else
                {
                    FireBullet(bullet, bullet.GetComponent<Bullet>().target,0);
                    //Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
                }
                fireTime = 0;
            }
        }
        else return;
    }

    private void FireBullet(GameObject _bullet, GameObject _target, float angle)
    {
        var projectileObject = Instantiate(_bullet, spawner.transform.position, spawner.transform.rotation);
        projectileObject.transform.Rotate(new Vector3(0,0,angle));
    }

    private void FireMultipleBullet(GameObject _bullet, GameObject _target)
    {
        int temp = 1;
        float tempAngle = multishot_angle;
        for (int i = 0; i < multishotNum; i++) {
            var projectileObject = Instantiate(_bullet, spawner.transform.position, spawner.transform.rotation);
            if (i == 0)
            {
                projectileObject.transform.Rotate(new Vector3(0, 0, 0));
                Debug.Log("초탄발사");
            }
            else if (i % 2 == 0) {
                projectileObject.transform.Rotate(new Vector3(0, 0, tempAngle*temp));
                temp++;
                Debug.Log($"{i}번째 멀티샷 발사");
            }
            else
            {
                projectileObject.transform.Rotate(new Vector3(0, 0, tempAngle*temp));
                Debug.Log($"{i}번째 멀티샷 발사");
            }
            tempAngle = -tempAngle;
        }
    }
}
