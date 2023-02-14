using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    //when I click on the Dot
    //it relocates to a random position (in floats)
    //somewhere between x:-6,6 y:-4,4
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //Debug.Log("Clicked on Dot");
        
        transform.position =
            new Vector3(
                Random.Range(-6, 6),
                Random.Range(-4, 4)
                );

        
        //increases by 1 every time you whack a dot
        GameManager.Instance.Score++;
    }
}
