using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 3.0f;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnPointGroup = GameObject.Find("SpawnPointGroup");
        points = spawnPointGroup.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
