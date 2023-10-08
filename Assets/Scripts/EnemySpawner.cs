using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 1f;

    [SerializeField] private GameObject[] EnemyPrefabs;
    public bool canSpawn=true;

    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        if (EnemyPrefabs.Length != 0)
        {
            while (canSpawn)
            {

                yield return wait;
                int rand = Random.Range(0, EnemyPrefabs.Length);
                GameObject enemyToSpawn = EnemyPrefabs[rand];

                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);


            }
        }
    }
}
