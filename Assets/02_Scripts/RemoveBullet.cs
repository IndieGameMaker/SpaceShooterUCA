using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    /*
        OnCollisionEnter
        OnCollisionStay
        OnCollisionExit

        OnTriggerEnter
        OnTriggerStay
        OnTriggerExit
    */

    [SerializeField] private GameObject _sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        //if (coll.collider.tag == "BULLET") // GC 발생

        if (coll.collider.CompareTag("BULLET"))
        {
            DestroyBullet(coll);
        }
    }

    void DestroyBullet(Collision coll)
    {
        // 충돌 좌표(지점)
        ContactPoint cp = coll.GetContact(0);

        Vector3 pos = cp.point; // 첫 번째 충돌 좌표
        Vector3 _normal = -1 * cp.normal; // 충돌한 지점의 법선 벡터

        var rot = Quaternion.LookRotation(_normal);

        var obj = Instantiate(_sparkEffect, pos, rot);
        Destroy(obj, 0.8f);

        Destroy(coll.gameObject);
    }

    /*
    Quaternion (쿼터니언 : 사원수) x, y, z, w
    짐벌락 (Gimbal Lock)를 방지하기 위해 사용하는 자료형
    
    */

}


/*
    AudioListener  => 1
    AudioSource => n 
*/