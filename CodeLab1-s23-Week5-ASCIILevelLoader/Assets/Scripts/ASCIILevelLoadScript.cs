using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoadScript : MonoBehaviour
{
    public GameObject player;
    public GameObject wall;
    
    const string FILE_NAME = "Level0.txt";
    const string FILE_DIR = "/Levels/";
    string FILE_PATH;

    public float xOffset;
    public float yOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;

        LoadLevel();
    }

    bool LoadLevel()
    {
        //load all the lines of the file into an array of strings
        string[] fileLines = File.ReadAllLines(FILE_PATH);

        //for loop to go through each line
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //get each line out of the array
            string lineText = fileLines[yPos];

            //turn the current line into an array of chars
            char[] lineChars = lineText.ToCharArray();

            //loop through each char
            for (int xPos = 0; xPos < lineChars.Length; xPos++)
            {
                //get the current char
                char c = lineChars[xPos];

                //make a variable for a new GameObject
                GameObject newObj = null;

                //is the char a p?
                if (c == 'p')
                {
                    //make a new player
                    newObj = Instantiate<GameObject>(player);
                }

                //is the char a w?
                if (c == 'w')
                {
                    //make a new wall
                    newObj = Instantiate<GameObject>(wall);
                }

                //if we made a new GameObject
                if (newObj != null)
                {
                    //position it based on where it was
                    //in the file, using the variables
                    //we used to loop through our arrays
                    newObj.transform.position =
                        new Vector2(
                            xOffset + xPos, 
                            yOffset - yPos);
                }
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
