using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    void Awake()
    {
        if (Instance == null) //Instance has not been set
        {
            DontDestroyOnLoad(gameObject); //dont destroy
            Instance = this; //and set instance to this GameManager
        }
        else //Instance is set
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
