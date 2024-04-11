using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;
    private float r;

    void Start()
    {

    }

    /* 단위벡터 (Unit Vector) / 정규화 벡터(Normalized Vector)

        Vector3.forward = Vector3(0, 0, 1)
        Vector3.up      = Vector3(0, 1, 0)
        Vector3.right   = Vector3(1, 0, 0)
    
        Vector3.one  = Vector3(1, 1, 1)
        Vector3.zero = Vector3(0, 0, 0)

    */

    private float speed = 5.0f;

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

        // Debug.Log($"moveDir = {moveDir.magnitude}");
        // Debug.Log($"moveDir 정규화 = {moveDir.normalized.magnitude}");

        //transform.position += Vector3.forward * v * Time.deltaTime * 5.0f;
    }

}
