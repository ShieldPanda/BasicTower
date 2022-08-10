using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    private const int _MAX = 30;

    public static WaypointManager _instance;

    public static WaypointManager instance { get { return _instance; } }

    private GameObject waypointGO;
    private GameObject[] waypoints = new GameObject[_MAX];
    private int waypointNum = 0; //측정된 웨이포인트의 수

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        waypointGO = GameObject.Find("Waypoints");

        //경로 탐색
        foreach (Transform child in waypointGO.transform)
        {
            waypoints[waypointNum] = child.gameObject;
            waypointNum++;
        }
        //Debug.Log("모든 경로 탐색 완료");
    }
    public GameObject getStartPoint()
    { //초기 위치 설정
        return waypoints[0]; 
    }
    public GameObject getNextPoint(int monsterPosition) {
        return waypoints[monsterPosition + 1];
    }
}
