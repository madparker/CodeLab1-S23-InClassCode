using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float forceAmount = 60;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up * forceAmount);
        }
    }
}
