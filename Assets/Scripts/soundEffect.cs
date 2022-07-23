using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour
{
    public AudioSource source;
    public AudioClip effect = null;
    float effectLength = 10.0f;
    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = effect;
        effectLength = effect.length+0.2f;
        source.Play();
        Destroy(gameObject, effectLength);
    }
}
