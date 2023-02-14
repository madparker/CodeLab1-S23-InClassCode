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

    public int gameLength = 10;
    public float timer = 0;

    public TextMeshPro displayText;

    bool inGame = true;
    
    //private score variable with a property
    int score = 0;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public List<int> highScores = new List<int>();

    string FILE_PATH;
    const string FILE_DIR  = "/Data/";
    const string FILE_NAME = "highScores.txt";
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
    }

    // Update is called once per frame
    void Update()
    {

        if (inGame)
        {
            timer += Time.deltaTime;
            //Debug.Log("Timer: " + timer);
            displayText.text = "Timer: " + (gameLength - (int)timer);
        }

        if (timer >= gameLength && inGame) 
        {
            inGame = false;
            Debug.Log("Game OVA!");
            SceneManager.LoadScene("EndScreen");
            UpdateHighScores();
        }
    }

    void UpdateHighScores()
    {
        //take the highscores out of the file and put them in the highScores list
        if (highScores.Count == 0) 
        {
            //if we already have high scores
            if (File.Exists(FILE_PATH))
            {
                //get the high scores from the file as a string
                string fileContents = File.ReadAllText(FILE_PATH);

                //split the string up into an array
                string[] fileSplit = fileContents.Split('\n');

                //go through all the strings that are numbers
                for (int i = 1; i < fileSplit.Length - 1; i++)
                {
                    //add the number (converted from a string) to highScores
                    highScores.Add(Int32.Parse(fileSplit[i]));
                }
            }
            else
            {
                //just add a place holder high score
                highScores.Add(0);
            }
        }

        //insert our score into the high scores list, if it's large enough
        for (int i = 0; i < highScores.Count; i++)
        {
            if (highScores[i] < Score)
            {
                highScores.Insert(i, Score);
                break;
            }
        }

        if (highScores.Count > 5) //if we have more than 5 high scores
        {
            //cut it to 5 high scores
            highScores.RemoveRange(5, highScores.Count - 5);
        }

        //make a string of all our high scores
        string highScoreStr = "High Scores:\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreStr += highScores[i] + "\n";
        }

        //display high scores
        displayText.text = highScoreStr;
        
        File.WriteAllText(FILE_PATH, highScoreStr);
    }
}
