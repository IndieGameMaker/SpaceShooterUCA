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
        Instantiate(_sparkEffect, coll.transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
    }

}


/*
    AudioListener  => 1
    AudioSource => n 
*/