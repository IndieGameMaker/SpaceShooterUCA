using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    Observer Pattern
    State Pattern
    Object Pooling
    Singleton Pattern
*/

public class GameManager : MonoBehaviour
{
    // 싱글턴 변수 선언
    public static GameManager Instance = null;

    public GameObject monsterPrefab;
    public List<Transform> points = new List<Transform>();

    [Header("Object Pooling")]
    // 오브젝트 풀링
    public List<GameObject> monsterPool = new List<GameObject>();
    // 오브젝트 풀링 최댓값
    public int maxPool = 10;

    // 몬스터 생성 주기
    public float createTime = 3.0f;
    public bool isGameOver = false;

    [Header("UI Settings")]
    public Image hpBar;

    void Awake()
    {
        Instance = this;
    }

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

        // 몬스터 풀 생성
        CreatePool();

        // 몬스터 생성 - 방법 #1
        // 이벤트명.Invoke();
        // Invoke("함수명", 지연시간);

        // InvokeRepeating(nameof(CreateMonster), 2.0f, createTime);
        StartCoroutine(CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        yield return new WaitForSeconds(2.0f);

        while (!isGameOver)
        {
            // 난수 발생
            int idx = Random.Range(1, points.Count);
            // 생성할 위치 추출
            Vector3 pos = points[idx].position;
            // 몬스터를 생성
            // Instantiate(monsterPrefab, pos, Quaternion.identity);

            // 몬스터를 오브젝트 풀링에서 추출
            foreach (var monster in monsterPool)
            {
                if (monster.activeSelf == false)
                {
                    monster.transform.position = pos;
                    monster.SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(createTime);
        }
    }

    void CreatePool()
    {
        for (int i = 0; i < maxPool; i++)
        {
            var monster = Instantiate(monsterPrefab);
            monster.name = $"Monster_{i}";
            monster.SetActive(false);

            monsterPool.Add(monster);
        }
    }

    public void DisplayHealth(float fillAmount)
    {
        hpBar.fillAmount = fillAmount;
    }
}
