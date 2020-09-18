using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h;
    private float v;

    void Start()
    {
        
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");   // -1.0f ~ 0.0f ~ +1.0f
        v = Input.GetAxis("Vertical");     // -1.0f ~ 0.0f ~ +1.0f 
        Debug.Log("h=" + h);    //Console View 로그 출력 
        Debug.Log("V=" + v);

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate( dir.normalized * 0.1f );

        // transform.position += new Vector3(0, 0, 0.1f);
        // transform.Translate( Vector3.forward * 0.1f * v );
        // transform.Translate( Vector3.right * 0.1f * h );

        /* 단위벡터, 정규화벡터 (Normalized Vector)
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.one     = Vector3(1, 1, 1)
            Vector3.zero    = Vecotr3(0, 0, 0)
        */
    }
}
