using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListExample : MonoBehaviour
{
    public InputField input;
    public TextAsset textFileWithNames;
    public Text display;

    private List<string> namesList;

    private void Start()
    {
        // Instantiate the list
        namesList = new List<string>();
        
        // The below code reads the text file and splits it into lines.
        var namesFromFile = textFileWithNames.text.Split('\n');

        // This code loops though every single line in the text file
        for (var i = 0; i < namesFromFile.Length; i++)
        {
            // Add each line to the list of namesList.
            namesList.Add(namesFromFile[i].ToUpper().Trim());
        }
        
        
        // Extra methods tests:
        
        Debug.Log("Count: " + namesList.Count);
        Debug.Log("Names contains \"JACK\":" + namesList.Contains("JACK"));
        Debug.Log("Names contains \"LANNI\":" + namesList.Contains("LANNI"));

        namesList.Insert(4520, "LANNI");

        var indexOfLastLanni = 0;

        for (int i = 0; i < namesList.Count; i++)
        {
            if (namesList[i] == "LANNI")
                indexOfLastLanni = i;
        }
       
        Debug.Log(namesList[4520]);
        namesList.RemoveAt(indexOfLastLanni);
        Debug.Log(namesList[4520]);


        // Debug.Log("Successfully removed \"LANNI\": " + namesList.Remove("LANNI"));
        // Debug.Log("Names contains\"LANNI\": " + namesList.Contains("LANNI"));
    }

    private void Update()
    {
        // If there's nothing in the text box, show instructions.
        if (input.text == "")
        {
            display.text = "Type a name to see if it's in the list!";
        }
        // Otherwise, check to see if the name is in the list.
        else
        {
            // Start by setting the display to say "not in list".
            display.text = "Not in the list.";
            

            // Loop through the entire list
            // for (int i = 0; i < namesList.Count; i++)
            // {
            //     // If any of the namesList in the list match what in the input field,
            //     // say it's in the list.
            //     if (input.text.ToUpper() == namesList[i])
            //     {
            //         display.text = "In the list!";
            //     }
            // }
            
            //TODO: Is there a better way to do this? With less code?
            //TODO: That will be faster?

            if (namesList.Contains(input.text.ToUpper()))
            {
                display.text = "In the list!";
            }

        }
    }
}
