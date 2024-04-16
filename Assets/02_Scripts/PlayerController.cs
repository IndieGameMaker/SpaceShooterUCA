using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;
    private float r;
    private float speed = 5.0f;

    [SerializeField]
    private Animation anim;

    private Animator animator;

    void Start()
    {
        anim = GetComponent<Animation>();   // Legacy Animation Type
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

    void PlayerAnim()
    {
        if (v >= 0.1f) // Up Arrow, W // 전진
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f) // 후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f) // 오른쪽 이동
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f) // 왼쪽 이동
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.1f);

            // anim.clip = anim.GetClip("Idle");
            // anim.Play()
        }
    }



}
