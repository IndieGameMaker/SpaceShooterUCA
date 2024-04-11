using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 추적할 대상의 Transform 컴포넌트
    [SerializeField] private Transform target;

    // 자신의 Transform 컴포넌트
    private Transform mainCamera;

    // 타겟으로 부터 떨어질 거리
    [Range(2.0f, 20.0f)]
    [SerializeField] private float distance = 10.0f;

    void Start()
    {

    }

    void Update()
    {

    }
}
