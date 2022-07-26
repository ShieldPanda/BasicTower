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
        //���� ��θ� �޾Ƽ� �� ������ ����ϴ� �� ���� ������Ʈ�� �����, ȿ���� ���� �� ������.
        effect = Resources.Load<AudioClip>($"Sounds/SFX/{path}");
        soundEffect se = Resources.Load<soundEffect>($"Prefabs/SoundEffect");
        se.effect = effect;
        se._volume = volume;
        Instantiate(se);
    }
}
