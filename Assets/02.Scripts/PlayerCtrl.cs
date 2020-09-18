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
    }
}
