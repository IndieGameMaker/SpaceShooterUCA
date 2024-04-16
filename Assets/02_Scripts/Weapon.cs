using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;
    [SerializeField] private AudioClip _fireSfx;
    [SerializeField] private MeshRenderer _muzzleFlash;

    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _muzzleFlash = _firePos.GetComponentInChildren<MeshRenderer>();
        _muzzleFlash.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            StartCoroutine(ShowMuzzleFlash());
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

    // 코루틴 Coroutine
    IEnumerator ShowMuzzleFlash()
    {
        // 오프셋 변경
        // (0, 0.5) (0.5, 0) (0.5, 0.5)
        // Random.Range(0, 2) => (0, 1) * 0.5 => (0, 0.5)

        Vector2 _offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        _muzzleFlash.material.mainTextureOffset = _offset;

        // 블랭크 효과
        _muzzleFlash.enabled = true;

        // Waiting...
        yield return new WaitForSeconds(0.2f);

        _muzzleFlash.enabled = false;
    }
}
