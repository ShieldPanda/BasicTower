using UnityEngine;
using System;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private const int SFX_max = 1;
    private static SoundManager _instance;
    public static SoundManager instance { get { return _instance; } }

    private GameObject SFXChannel;
    private GameObject musicChannel;

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

        musicChannel = gameObjectDDOL(musicChannel, "Music");
        SFXChannel = gameObjectDDOL(SFXChannel,"SFX");
        
        musicChannel.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Music/terran");
        musicChannel.GetComponent<AudioSource>().Play();
    }

    private GameObject gameObjectDDOL(GameObject IG, string Gname)
    {
        GameObject gameOb = GameObject.Find(Gname);
        if (gameOb == null)
        {
            gameOb = new GameObject();
            gameOb.name = Gname;
            gameOb.AddComponent<AudioSource>();
        }

        DontDestroyOnLoad(gameOb);

        return gameOb;
    }

    private AudioClip effect;

    public void createSoundEffects(string path, float volume = 1.0f) {

        //파일 경로를 받아서 SFX 채널 중 하나에서 파일을 재생하도록 함.
        effect = Resources.Load<AudioClip>($"Sounds/SFX/{path}");
        AudioSource SFX;
        SFX = SFXChannel.GetComponent<AudioSource>();
        SFX.PlayOneShot(effect);
    }
}
