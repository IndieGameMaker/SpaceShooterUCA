using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;
    [SerializeField] private AudioClip _fireSfx;

    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 총소리 발생
        // _audio.clip = _fireSfx;
        // _audio.Play();

        _audio.PlayOneShot(_fireSfx, 0.8f);

        Instantiate(_bulletPrefab, _firePos.position, _firePos.rotation);
    }
}
