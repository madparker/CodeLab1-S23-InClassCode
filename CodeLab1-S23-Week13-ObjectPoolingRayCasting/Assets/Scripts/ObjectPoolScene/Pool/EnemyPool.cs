using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    public GameObject enemy; //Type of gameObject for this pool

    public static EnemyPool instance; //holds singleton reference

    void Start()
    {
        //set up the singleton
        if (instance == null)
        { //if instance isn't set
            instance = this; //set it to this instance
            DontDestroyOnLoad(gameObject); //Don't destory this gameObject
        }
        else
        { //otherwise, if we have a singleton already
            Destroy(gameObject); //Destroy this instance
        }
    }

    //override abstract method, make it return a new enemy
    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(enemy);
    }

    //wrapper around "Get" from base, sets up enemy to be used again
    public GameObject GetEnemy()
    {
        GameObject recycledEnemy = Get(); //enemy off of the stack

        recycledEnemy.GetComponent<EnemyScript>().Reset(); //reset it

        return recycledEnemy; //return it
    }
}

