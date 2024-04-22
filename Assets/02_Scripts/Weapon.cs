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

    private Light _fireLight;

    private AudioSource _audio;

    //private RaycastHit hit;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _muzzleFlash = _firePos.GetComponentInChildren<MeshRenderer>();
        _muzzleFlash.enabled = false;

        _fireLight = _firePos.GetComponentInChildren<Light>();
        _fireLight.intensity = 0.0f;
    }

    void Update()
    {
        // Ray 표시
        Debug.DrawRay(_firePos.position, _firePos.forward * 10.0f, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            StartCoroutine(ShowMuzzleFlash());

            // (광선원점, 광선방향, 충돌객제정보, 광선의거리)
            if (Physics.Raycast(_firePos.position, _firePos.forward, out RaycastHit hit, 10.0f, 1 << 10)) // 2^10
            {
                Debug.Log(hit.collider.gameObject.name);

                hit.collider.GetComponent<MonsterController>().Damage();
            }
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

        // Scale
        Vector3 _scale = Vector3.one * Random.Range(1.0f, 3.0f);
        _muzzleFlash.transform.localScale = _scale;

        // 회전처리
        float angle = Random.Range(0, 360);
        Quaternion rot = Quaternion.Euler(Vector3.forward * angle);
        _muzzleFlash.transform.localRotation = rot;

        // 조명
        _fireLight.intensity = Random.Range(2.0f, 5.0f);

        // 블랭크 효과
        _muzzleFlash.enabled = true;

        // Waiting...
        yield return new WaitForSeconds(0.2f);

        _muzzleFlash.enabled = false;
        _fireLight.intensity = 0.0f;
    }
}

/*
    NPC AI 구현 기법

    1. 유한 상태 머신 (Finite State Machine) FSM
        - HFSM
    2. Behaviour Tree

    MUSE Chat
    MUSE Texture
    MUSE Animation
    MUSE Behaviour Tree
    Sentise

*/