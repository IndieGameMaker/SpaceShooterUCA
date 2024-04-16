using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public enum State { IDLE, TRACE, ATTACK, DIE }

    // 몬스터의 상태를 저장하는 변수
    [SerializeField] private State _state = State.IDLE;

    // 추적 사정거리
    [SerializeField] private float _traceDist = 10.0f;
    // 공격 사정거리
    [SerializeField] private float _attackDist = 2.0f;

    private Transform _monsterTr;
    private Transform _playerTr;

    void Start()
    {
        _monsterTr = transform; // GetComponent<Transform>();
        _playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        if (_playerTr == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
