using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum STATE
{
    IDLE,
    TRACE,
    ATTACK,
    DIE
}

public class MonsterCtrl : MonoBehaviour
{
    //몬스터의 상태
    public STATE state = STATE.IDLE;

    private Transform monsterTr;
    private Transform playerTr;

    private NavMeshAgent agent;
    private Animator anim;

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;

    //몬스터의 사망여부
    public bool isDie = false;

    //Animator Parametor Hash 미리 추출
    private int hashAttack;
    private int hashHit;

    // Start is called before the first frame update
    void Start()
    {
        hashAttack = Animator.StringToHash("IsAttack");
        hashHit    = Animator.StringToHash("Hit");

        monsterTr = GetComponent<Transform>(); //monsterTr = transform;
        GameObject playerObj = GameObject.FindGameObjectWithTag("PLAYER"); //GameObject.Find("Player");
        if (playerObj != null)
        {
            playerTr = playerObj.GetComponent<Transform>();
        }

        agent = GetComponent<NavMeshAgent>();
        anim  = GetComponent<Animator>();

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());
    }

    //몬스터의 상태만 계속 체크하는 코루틴
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            //1. 두점간의 거리 계산
            float dist = Vector3.Distance(monsterTr.position, playerTr.position);

            if (dist <= attackDist)
            {
                state = STATE.ATTACK;
            }
            else if (dist <= traceDist)
            {
                state = STATE.TRACE;
            }
            else
            {
                state = STATE.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    //몬스터의 상태에 따라서 행동을 분기처리하는 코루틴
    IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            switch (state)
            {
                case STATE.IDLE:
                    agent.isStopped = true;
                    anim.SetBool("IsTrace", false);
                    break;
                case STATE.TRACE:
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;

                    anim.SetBool(hashAttack, false);
                    anim.SetBool("IsTrace", true);
                    break;
                case STATE.ATTACK:
                    agent.isStopped = true;
                    anim.SetBool(hashAttack, true);
                    break;
                case STATE.DIE:
                    break;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
        }
    }

}
