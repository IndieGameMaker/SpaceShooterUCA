using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public List<Transform> points = new List<Transform>();

    void Start()
    {
        // SpawnPointGroup GameObject를 검색
        GameObject group = GameObject.Find("SpawnPointGroup");
        // List 변수에 할당
        group?.GetComponentsInChildren<Transform>(points);

        // Resources 폴더에 있는 Asset(Prefab)을 로드
        monsterPrefab = Resources.Load<GameObject>("Monster");
    }

}
