using UnityEngine;

public class soundEffect : MonoBehaviour
{
    public AudioSource source;
    public AudioClip effect = null;
    public float _volume = 1.0f;
    float effectLength = 10.0f;
    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.volume = _volume;
        source.clip = effect;
        effectLength = effect.length+0.2f;
        source.Play();
        Destroy(gameObject, effectLength);
    }
}
