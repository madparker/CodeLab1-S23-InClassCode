using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extends abstract ObjectPool
public class BulletPool : ObjectPool
{
    public GameObject bullet; //Type of gameObject for this pool

    public static BulletPool instance; //holds singleton reference

    void Start()
    {
        //set up the singleton
        if (instance == null) //if instance isn't set
        {
            instance = this; //set it to this instance
            DontDestroyOnLoad(gameObject); //Don't destory this gameObject
        }
        else  //otherwise, if we have a singleton already
        {
            Destroy(gameObject); //Destroy this instance
        }

        //insert 3 bullets into pool
        //this class will allow a maximum of 3 bullets at once
        Push(GetNewObject());
        Push(GetNewObject());
        Push(GetNewObject());
    }

    //override abstract method, make it return a new bullet
    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(bullet);
    }

    //wrapper around "Get" from base, sets up bullet to be used again
    public GameObject GetBullet()
    {
        if(pool.Count == 0){ //if there's nothing in the pool
            return null; //don't make a new bullet
        } else { //otherwise
            GameObject bullet = Get(); //get a bullet out

            bullet.GetComponent<BulletScript>().Reset(); //reset it

            return bullet; //return it
        }
    }
}
