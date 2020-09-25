using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    private Transform monsterTr;
    private Transform playerTr;

    private NavMeshAgent agent;

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

    }

    void Update()
    {
        agent.SetDestination(playerTr.position);
    }


}
