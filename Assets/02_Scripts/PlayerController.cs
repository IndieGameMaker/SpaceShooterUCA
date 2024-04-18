using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;
    private float r;
    private float speed = 5.0f;

    private Animator animator;

    private int initHp = 100;
    private int currHp = 100;

    void Start()
    {
        animator = GetComponent<Animator>();// Mecanim Animation Type
    }

    void Update()
    {
        // InputManager
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        //Vector3 moveDir = (전진후진 벡터) +(좌우 벡터);
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * r * 200.0f);

        animator.SetFloat("forward", v);
        animator.SetFloat("strafe", h);

        //PlayerAnim();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PUNCH"))
        {
            currHp -= 10;
            if (currHp <= 0)
            {
                PlayerDie();
            }
        }
    }

    private void PlayerDie()
    {
        // 스테이지에 생성된 모든 몬스터를 추출해서 배열 저장
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");

        foreach (var monster in monsters)
        {
            monster.GetComponent<MonsterController>().YouWin();
        }
    }
}
