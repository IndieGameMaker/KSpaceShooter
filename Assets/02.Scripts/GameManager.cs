using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 3.0f;

    public bool isGameOver = false;

    private WaitForSeconds ws;

    // Start is called before the first frame update
    void Start()
    {
        ws = new WaitForSeconds(createTime);

        GameObject spawnPointGroup = GameObject.Find("SpawnPointGroup");
        points = spawnPointGroup.GetComponentsInChildren<Transform>();

        monsterPrefab = Resources.Load<GameObject>("monster");

        StartCoroutine(this.CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        while(!isGameOver)
        {
            yield return ws;

            int idx = Random.Range(1, points.Length);

            GameObject monster = Instantiate<GameObject>(monsterPrefab);
            monster.transform.position = points[idx].position;
            Vector3 dir = points[0].position - points[idx].position;
            monster.transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
