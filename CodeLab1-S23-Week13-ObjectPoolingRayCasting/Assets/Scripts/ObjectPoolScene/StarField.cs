using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    public float intervalMin = 0.1f; //min time to span new star
    public float intervalMax = 0.5f; //max time to span new star
    public float numStars = 10; //how many stars to span at once

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnStar", intervalMin); //call SpawnStar after intervalMin time
    }

    void SpawnStar()
    {
        //generate numStars stars
        for (int i = 0; i < numStars; i++){
            GameObject star = StarPool.instance.GetStar();
        }

        //call SpawnStar again after a random amount of time between min and max
        Invoke("SpawnStar", Random.Range(intervalMin, intervalMax));
    }
}
