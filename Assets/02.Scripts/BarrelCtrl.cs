using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    private int hitCount = 0;

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

        Instantiate(expEffect, this.transform.position, Quaternion.identity);
    }
}
