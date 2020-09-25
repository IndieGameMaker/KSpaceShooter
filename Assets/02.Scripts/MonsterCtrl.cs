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

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;

    //몬스터의 사망여부
    public bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        monsterTr = GetComponent<Transform>(); //monsterTr = transform;
        GameObject playerObj = GameObject.FindGameObjectWithTag("PLAYER"); //GameObject.Find("Player");
        if (playerObj != null)
        {
            playerTr = playerObj.GetComponent<Transform>();
        }

        agent = GetComponent<NavMeshAgent>();

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
                    break;
                case STATE.TRACE:
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    break;
                case STATE.ATTACK:
                    break;
                case STATE.DIE:
                    break;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }


}
