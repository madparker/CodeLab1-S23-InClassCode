using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int score = 0;

    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "highScore.txt";
    string PATH_HIGH_SCORE;

    public const string PREF_HIGH_SCORE = "hsScore";

    public int Score
    {
        get { return score; }
        set
        {
            score = value; 
            Debug.Log("THE SCORE CHANGED!!!");

            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore = 2;

    public int HighScore
    {
        get
        {
            //highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE, 1);
            return highScore;
        }
        set
        {
            highScore = value;

            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_HIGH_SCORE, "" + highScore);
            
            //PlayerPrefs.SetInt(PREF_HIGH_SCORE, highScore);
        }
    }


    public int currentLevel = 0;

    public int targetScore = 2;

    public TextMeshPro textMeshPro;

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
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE;

        if (File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }
        //highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //PlayerPrefs.DeleteKey(PREF_HIGH_SCORE);
            //File.WriteAllText(PATH_HIGH_SCORE, "2");
            File.Delete(PATH_HIGH_SCORE);
        }

        textMeshPro.text= 
            "Level: " + (currentLevel + 1) + "\n" + 
            "Score: " + score + "\n" + 
            "High Score: " + HighScore;

        if (score == targetScore) //if we hit the target score
        {
            currentLevel++; //increase the level
            targetScore = targetScore * 2; //increase the target
            SceneManager.LoadScene(currentLevel); //go to the next level
        }
    }
}
