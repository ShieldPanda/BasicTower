using UnityEngine;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{
    [SerializeField]
    SoundDictionary soundDict;
    public IDictionary<string, AudioClip> SoundDictionary
    {
        get { return soundDict; }
        set { soundDict.CopyFrom(value); }
    }

    private static SoundManager _instance;
    public static SoundManager instance { get { return _instance; } }

    private AudioSource soundChannel;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }

        soundChannel = gameObject.GetComponent<AudioSource>();
        
        soundChannel.GetComponent<AudioSource>().clip = soundDict.GetValueOrDefault("BattleMusic");
        soundChannel.GetComponent<AudioSource>().Play();
    }


    private AudioClip effect;

    public void createSoundEffects(string sfxname, float volume = 1.0f) {
        //���� ��θ� �޾Ƽ� SFX ä�� �� �ϳ����� ������ ����ϵ��� ��.
        effect = soundDict.GetValueOrDefault(sfxname);
        //���� ������ ����� �� ã�ƺ��� �ҵ�
        //https://www.youtube.com/watch?v=LfU5xotjbPw
        soundChannel.PlayOneShot(effect);
    }
}
