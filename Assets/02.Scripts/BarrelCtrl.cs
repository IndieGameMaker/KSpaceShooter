﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    private int hitCount = 0;

    public Texture[] textures;
    private MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponentInChildren<MeshRenderer>();

        int idx = Random.Range(0, textures.Length); //(0, 3)  -> 0, 1, 2
        _renderer.material.mainTexture = textures[idx];
    }

    void OnCollisionEnter(Collision coll)
    {
        //if (coll.collider.tag == "BULLET") //GC
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3) ExpBarrel();
        }
    }

    void ExpBarrel()
    {
        var rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1500.0f);
        Destroy(this.gameObject, 2.0f);

        var obj = Instantiate(expEffect, this.transform.position, Quaternion.identity);
        Destroy(obj, 5.0f);
    }
}
