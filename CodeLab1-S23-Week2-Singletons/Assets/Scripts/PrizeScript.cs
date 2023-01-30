using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrizeScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        transform.position = new Vector2(
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f));

        GameManager.Instance.score++;
    }
}
