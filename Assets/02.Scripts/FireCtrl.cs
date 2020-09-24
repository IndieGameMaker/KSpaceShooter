using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    private AudioSource _audio;
    public AudioClip fireSfx;
    public MeshRenderer muzzleFlash;
    
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        //Bullet 생성
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        //총소리 발생
        // _audio.clip = fireSfx;
        // _audio.Play();
        _audio.PlayOneShot(fireSfx, 0.8f);
    }
}
