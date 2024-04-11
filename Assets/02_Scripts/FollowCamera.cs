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
    // Y축 높이
    [SerializeField] private float height = 2.5f;

    // Offset
    [SerializeField] private float offset = 1.0f;

    void Start()
    {
        mainCamera = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // 추적 대상으로 부터 뒤쪽으로 이동
        mainCamera.position = target.position - (target.forward * distance) + (Vector3.up * height);
        mainCamera.LookAt(target.position + (Vector3.up * offset));
    }
}
