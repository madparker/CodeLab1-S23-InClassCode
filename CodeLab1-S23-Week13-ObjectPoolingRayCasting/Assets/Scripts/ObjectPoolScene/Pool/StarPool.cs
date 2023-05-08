using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extends abstract ObjectPool
public class StarPool : ObjectPool
{
    public GameObject star; //Type of gameObject for this pool

    public static StarPool instance; //holds singleton reference

    void Start()
    {
        //set up the singleton
        if(instance == null){ //if instance isn't set
            instance = this; //set it to this instance
            DontDestroyOnLoad(gameObject); //Don't destory this gameObject
        } else { //otherwise, if we have a singleton already
            Destroy(gameObject); //Destroy this instance
        }
    }

    //override abstract method, make it return a new star
    protected override GameObject GetNewObject(){
        return Instantiate<GameObject>(star);
    }

    //wrapper around "Get" from base, sets up star to be used again
    public GameObject GetStar(){
        GameObject recycledStar = Get(); //Star our of the stack

        recycledStar.GetComponent<StarScript>().Reset(); //reset it

        return recycledStar; //return it
    }
}
