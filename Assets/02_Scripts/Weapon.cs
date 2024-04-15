using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;
    [SerializeField] private AudioClip _fireSfx;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_bulletPrefab, _firePos.position, _firePos.rotation);
        }
    }
}
