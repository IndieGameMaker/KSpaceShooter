using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            ContactPoint[] points = coll.contacts;
            Vector3 pos = points[0].point;
            //법선벡터가 이루고 있는 각도를 쿼터니언 타입으로 치환
            Quaternion rot = Quaternion.LookRotation(points[0].normal); 
            GameObject spark = Instantiate(sparkEffect, pos, rot); //(생성할 객체, 위치, 각도)
            Destroy(spark, 0.5f); //Delay time

            Destroy(coll.gameObject); //Bullet
        }
    }
}
