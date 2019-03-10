using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    public bool booler;

    int randEnemy;


    void Start()
    {
    }

    void Update()
    {
            StartCoroutine(wSpawner());

        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator wSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!booler)
        {
            randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
