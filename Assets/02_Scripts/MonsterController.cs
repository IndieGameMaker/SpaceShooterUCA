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

    [SerializeField] private bool _isDie = false;

    void Start()
    {
        _monsterTr = transform; // GetComponent<Transform>();
        _playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        if (_playerTr == null)
        {
            Debug.LogError("Player not found!");
        }

        StartCoroutine(CheckMonsterState());
    }

    IEnumerator CheckMonsterState()
    {
        while (_isDie == false)
        {
            // 두점간의 거리
            //float distance = Vector3.Distance(_monsterTr.position, _playerTr.position);
            float distance = (_monsterTr.position - _playerTr.position).sqrMagnitude;

            Debug.Log(Mathf.Sqrt(distance));

            if (distance <= _attackDist * _attackDist) // 공격 사정거리 이내인 경우
            {
                _state = State.ATTACK;
            }
            else if (distance <= _traceDist * _traceDist)
            {
                _state = State.TRACE;
            }
            else
            {
                _state = State.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

}
