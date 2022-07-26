using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private GameObject sManager;
    private SoundManager sM;
    private int heart;
    private int maxHeart = 2;

    // Start is called before the first frame update
    void Start()
    {
        sManager = GameObject.Find("@SoundManager");
        sM = sManager.GetComponent<SoundManager>();
        if (heart != maxHeart) { heart = maxHeart; }
    }

    public void setHeart(int monsterHeart, int addHeart = 0) {
        heart += addHeart;
        heart -= monsterHeart;
        Debug.Log($"현재 하트 수 : {heart}");
        if (heart <= 0) {
            //game over
            Debug.Log("으앙 주금");
            sM.createSoundEffects("youlose");
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

    public int getHeart() { return heart; }
}
