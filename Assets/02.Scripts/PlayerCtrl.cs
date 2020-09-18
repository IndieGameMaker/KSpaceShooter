using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
    public AnimationClip[] dies;
}

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private float h;
    private float v;
    private float r;

    public float moveSpeed = 15.0f;
    public float turnSpeed = 80.0f;

    public PlayerAnim playerAnim;

    [HideInInspector]
    public Animation anim;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        // anim.clip = "Idle";
        // anim.Play();

        //anim.Play("Idle");
        anim.Play(playerAnim.idle.name);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");   // -1.0f ~ 0.0f ~ +1.0f
        v = Input.GetAxis("Vertical");     // -1.0f ~ 0.0f ~ +1.0f 
        r = Input.GetAxis("Mouse X");

        // Debug.Log("h=" + h);    //Console View 로그 출력 
        // Debug.Log("V=" + v);

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate( dir.normalized * Time.deltaTime * moveSpeed );
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r );

        SwithAnimation(h, v);

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

    void SwithAnimation(float h, float v)
    {
        if (v >= 0.1f) //Forward
        {
            anim.CrossFade(playerAnim.runForward.name, 0.25f);
        }
        else if (v <= -0.1f) //Backward
        {
            anim.CrossFade(playerAnim.runBackward.name, 0.25f);
        }
        else if (h >= 0.1f) //Right
        {
            anim.CrossFade(playerAnim.runRight.name, 0.25f);
        }
        else if (h <= -0.1f) //Left
        {
            anim.CrossFade(playerAnim.runLeft.name, 0.25f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.25f);
        }
    }
}
