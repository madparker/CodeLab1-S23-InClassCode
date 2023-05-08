using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public float xRange; //random range for star pos on the x axis

    const float MIN_SPEED = 0.001f; //min speed
    const float MAX_SPEED = 0.005f; //max speed
    const float MAX_Y = 10; //where to start star
    const float MIN_Y = -10; //where to recycle star

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        Reset(); //setup star
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED); //give it a randome speed in range

        //set random star pos
        transform.position = new Vector2( 
            Random.Range(-xRange, xRange),
            MAX_Y);
    }

    // Update is called once per frame
    void Update()
    {
        //move star by speed
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y + speed);

        //if the star has gone to far
        if(transform.position.y < MIN_Y){
            StarPool.instance.Push(gameObject); //recycle it into the pool
        }
    }
}
