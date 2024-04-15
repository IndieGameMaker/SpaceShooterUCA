using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarrelController : MonoBehaviour
{
    [SerializeField] private GameObject _expEffect;
    private int hitCount;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                // 폭발 효과
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        var rb = this.gameObject.AddComponent<Rigidbody>();

        Vector3 pos = Random.insideUnitSphere;

        rb.AddExplosionForce(1500.0f, transform.position + pos, 5.0f, 1800.0f);
    }
}
