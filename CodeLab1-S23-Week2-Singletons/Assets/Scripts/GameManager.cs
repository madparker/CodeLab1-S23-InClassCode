using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int score = 0;

    public int currentLevel = 0;

    public int targetScore = 2;

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
        if (score == targetScore) //if we hit the target score
        {
            currentLevel++; //increase the level
            targetScore = targetScore * 2; //increase the target
            SceneManager.LoadScene(currentLevel); //go to the next level
        }
    }
}
