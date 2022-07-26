using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject bullet = null;
    GameObject spawner = null;
    public enum bulletType { Bullet_normal, Bullet_homing }
    public bulletType btype;
    float fireTime = 0;
    public float fireTimeLimit = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        bullet =  Resources.Load<GameObject>($"Prefabs/{btype.ToString()}");
        spawner = transform.Find("tower_bulletSpawner").gameObject;
    }

    // Update is called once per frame
    void Update()
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
                bullet.GetComponent<Bullet>().target = other.gameObject;
                //Debug.Log("발사!");
                Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
                fireTime = 0;
            }
        }
        else return;
    }

}
