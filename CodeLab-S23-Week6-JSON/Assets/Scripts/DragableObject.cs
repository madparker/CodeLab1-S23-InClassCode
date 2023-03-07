using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    string file_path;
    
    // Start is called before the first frame update
    void Start()
    {
        file_path = Application.dataPath + "/Data/" + name + ".json";

        if (File.Exists(file_path))
        {
            string fileContents = File.ReadAllText(file_path);

            transform.position = JsonUtility.FromJson<Vector3>(fileContents);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnApplicationQuit()
    {
        string jsonPosition = JsonUtility.ToJson(transform.position, true);
        
        Debug.Log(jsonPosition);
        
        File.WriteAllText(file_path, jsonPosition);
    }
}
