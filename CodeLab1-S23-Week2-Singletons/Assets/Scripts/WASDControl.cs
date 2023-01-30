using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{
    public static WASDControl Instance;
    
    Rigidbody2D rb2d;

    public float forceAmount = 60;

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
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * forceAmount);
        }

        rb2d.velocity *= 0.999f;

    }
}
