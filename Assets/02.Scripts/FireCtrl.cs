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
        muzzleFlash.enabled = false;
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

        //Muzzle Flash Show
        StartCoroutine(this.ShowMuzzleFlash());
    }

    //Coroutine 
    IEnumerator ShowMuzzleFlash()
    {
        //회전처리
        float angle = Random.Range(0, 360); //0 ~ 359
        Quaternion rot = Quaternion.Euler(0, 0, angle);
        muzzleFlash.transform.localRotation = rot;

        //Scale
        float scale = Random.Range(1.0f, 3.0f); //0.0f ~ 3.0f
        muzzleFlash.transform.localScale = Vector3.one * scale;   //new Vector3(scale, scale, scale);

        muzzleFlash.enabled = true;
        //Waitting...
        yield return new WaitForSeconds(0.3f);
        muzzleFlash.enabled = false;
    }
}
