using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public List<Transform> points = new List<Transform>();

    // 몬스터 생성 주기
    public float createTime = 3.0f;

    public bool isGameOver = false;

    void OnEnable()
    {
        // PlayerController.OnPlayerDie += () => CancelInvoke(); // Lamda 식

        // 델리게이트 - 익명 메소드
        // PlayerController.OnPlayerDie += delegate ()
        // {
        //     isGameOver = true;
        //     Debug.Log("플레이어 사망");
        // };

        // 람다식  // Goes to
        PlayerController.OnPlayerDie += () => isGameOver = true;
    }

    void Start()
    {
        // SpawnPointGroup GameObject를 검색
        GameObject group = GameObject.Find("SpawnPointGroup");
        // List 변수에 할당
        group?.GetComponentsInChildren<Transform>(points);

        // Resources 폴더에 있는 Asset(Prefab)을 로드
        monsterPrefab = Resources.Load<GameObject>("Monster");

        // 몬스터 생성 - 방법 #1
        // 이벤트명.Invoke();
        // Invoke("함수명", 지연시간);

        // InvokeRepeating(nameof(CreateMonster), 2.0f, createTime);
        StartCoroutine(CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            // 난수 발생
            int idx = Random.Range(1, points.Count);
            // 생성할 위치 추출
            Vector3 pos = points[idx].position;
            // 몬스터를 생성
            Instantiate(monsterPrefab, pos, Quaternion.identity);

            yield return new WaitForSeconds(createTime);
        }
    }
}
