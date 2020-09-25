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
    public Light fireLight;

    [Range(5.0f, 20.0f)]
    public float fireRange = 10.0f;

    private RaycastHit hit;
    
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
        fireLight.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(firePos.position, firePos.forward * fireRange, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            if (Physics.Raycast(firePos.position, firePos.forward, out hit, fireRange))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

    void Fire()
    {
        //Bullet 생성
        //Instantiate(bulletPrefab, firePos.position, firePos.rotation);

        //총소리 발생
        // _audio.clip = fireSfx;
        // _audio.Play();
        _audio.PlayOneShot(fireSfx, 0.1f);

        //Muzzle Flash Show
        StartCoroutine(this.ShowMuzzleFlash());
    }

    //Coroutine 
    IEnumerator ShowMuzzleFlash()
    {
        //회전처리
        float angle = UnityEngine.Random.Range(0, 360); //0 ~ 359
        Quaternion rot = Quaternion.Euler(0, 0, angle);
        muzzleFlash.transform.localRotation = rot;

        //Scale
        float scale = UnityEngine.Random.Range(1.0f, 3.0f); //0.0f ~ 3.0f
        muzzleFlash.transform.localScale = Vector3.one * scale;   //new Vector3(scale, scale, scale);

        //Texture Offset
        // (0, 0) (0, 0.5) (0.5, 0) (0.5, 0.5) x = 0 , 0.5 / y = 0, 0.5 
        // (0, 1) * 0.5f
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        //Light On
        fireLight.intensity = Random.Range(1.0f, 3.0f);

        muzzleFlash.enabled = true;
        //Waitting...
        yield return new WaitForSeconds(0.3f);

        muzzleFlash.enabled = false;
        //Light Off
        fireLight.intensity = 0.0f;
    }
}
