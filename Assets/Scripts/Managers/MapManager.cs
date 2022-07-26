using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;

    public static MapManager instance { get { return _instance; } }

    private int heart;
    private int maxHeart = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
        if (heart != maxHeart) { heart = maxHeart; }
    }

    public void setHeart(int monsterHeart, int addHeart = 0) {
        heart += addHeart;
        heart -= monsterHeart;
        Debug.Log($"���� ��Ʈ �� : {heart}");
        if (heart <= 0) {
            Debug.Log("���ӿ���");
            SoundManager.instance.createSoundEffects("youlose");
            Time.timeScale = 0;
     /*       
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
     */
        }
    }
}
