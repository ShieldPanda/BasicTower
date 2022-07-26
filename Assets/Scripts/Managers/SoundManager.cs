using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioClip effect;
    public void createSoundEffects(string path , float volume = 1.0f) {
        //���� ��θ� �޾Ƽ� �� ������ ����ϴ� �� ���� ������Ʈ�� �����, ȿ���� ���� �� ������.
        effect = Resources.Load<AudioClip>($"Sounds/SFX/{path}");
        soundEffect se = Resources.Load<soundEffect>($"Prefabs/SoundEffect");
        se.effect = effect;
        se._volume = volume;
        Instantiate(se);
    }
}
