using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private WaitForSeconds ws;
    private NavMeshAgent agent;
    private Animator animator;

    // Animator Controller의 Parameter Hash 추출
    private int hashIsTrace = Animator.StringToHash("IsTrace");
    private int hashIsAttack = Animator.StringToHash("IsAttack");
    private int hashHit = Animator.StringToHash("Hit");
    private int hashDie = Animator.StringToHash("Die");

    [SerializeField] private int hp = 100;

    void Start()
    {
        ws = new WaitForSeconds(0.5f);
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        _monsterTr = transform; // GetComponent<Transform>();
        _playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        if (_playerTr == null)
        {
            Debug.LogError("Player not found!");
        }

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    // 몬스터의 상태값을 변경시키는 메소드
    IEnumerator CheckMonsterState()
    {
        while (_isDie == false)
        {
            if (_state == State.DIE) yield break;

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

            yield return ws;
        }
    }

    // 몬스터의 상태에 따라서 행동을 처리하는 메소드
    IEnumerator MonsterAction()
    {
        while (!_isDie)
        {
            switch (_state)
            {
                case State.IDLE:
                    // 추적 정지
                    agent.isStopped = true;
                    animator.SetBool(hashIsTrace, false);
                    break;

                case State.TRACE:
                    // 추적 시작
                    agent.SetDestination(_playerTr.position);
                    agent.isStopped = false; // agent.Stop(); agent.Resume()
                    // 추적 애니메이션으로 변경
                    animator.SetBool(hashIsAttack, false);
                    animator.SetBool(hashIsTrace, true);
                    break;

                case State.ATTACK:
                    // 공격애니메이션 처리
                    animator.SetBool(hashIsAttack, true);
                    break;

                case State.DIE:
                    //애니메이션 
                    animator.SetTrigger(hashDie);
                    agent.isStopped = true;
                    _isDie = true;
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

            yield return ws;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
            animator.SetTrigger(hashHit);

            hp -= 20;
            if (hp <= 0)
            {
                _state = State.DIE;
            }
            // _state = (hp <= 0) ? State.DIE : _state;
        }
    }


}


/*
    NavMeshAgent의 길찾기 알고리즘

    A* PathFinding 

*/