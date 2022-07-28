using UnityEngine;

public class soundEffect : MonoBehaviour
{
    public float _volume = 1.0f;
    private float effectLength = 10.0f;
    public AudioSource source;
    public AudioClip effect = null;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.volume = _volume;
        source.clip = effect;
        effectLength = effect.length+0.2f;
        source.Play();
        Destroy(gameObject, effectLength);
    }
}
