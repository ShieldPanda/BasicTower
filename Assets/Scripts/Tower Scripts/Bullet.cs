using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float spantime = 4.0f;
    protected int dam = 1;
    protected float Bspeed = 2.0f;
    protected Vector3 dir;
    public AudioClip fireSound;
    protected AudioSource ad;
    public GameObject target = null;
}
