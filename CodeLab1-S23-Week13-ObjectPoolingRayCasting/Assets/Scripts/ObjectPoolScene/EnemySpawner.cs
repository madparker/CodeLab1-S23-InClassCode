using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float interval = 2f; //time to span new star

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", interval, interval); //call SpawnEnemy after intervalMin time
    }

    void SpawnEnemy()
    {
        GameObject enemy = EnemyPool.instance.GetEnemy();
    }
}
