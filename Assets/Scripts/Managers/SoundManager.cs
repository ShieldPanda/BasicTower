using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager instance { get { return _instance; } }

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
    }

    private AudioClip effect;
    public void createSoundEffects(string path, float volume = 1.0f) {
        //파일 경로를 받아서 그 파일을 재생하는 빈 게임 오브젝트를 만들고, 효과음 종료 시 삭제함.
        effect = Resources.Load<AudioClip>($"Sounds/SFX/{path}");
        soundEffect se = Resources.Load<soundEffect>($"Prefabs/SoundEffect");
        se.effect = effect;
        se._volume = volume;
        Instantiate(se);
    }
}
