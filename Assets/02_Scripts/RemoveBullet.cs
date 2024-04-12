using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    void OnCollisionEnter(Collision coll)
    {
        //if (coll.collider.tag == "BULLET") // GC 발생

        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
        }
    }

}
