using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSRayCasting : MonoBehaviour
{
    
    bool debugMode = true; //bool for whether not to execute debug code
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (debugMode) //if in debug mode
        {
            //create a ray from this position to the "forward" of this position
            Ray ray = new Ray(transform.position, transform.forward);
            //draw a ray (in sceneview) 
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        }
        
        if (Input.GetMouseButtonDown(0)) { // if clicked
            RaycastHit hit; //create a new Raycast hit handle

            //create a ray from this position to the "forward" of this position
            Ray ray = new Ray(transform.position, transform.forward);

            //there's a Raycast that hits something at a distnace less than 10 units
            if (Physics.Raycast(ray, out hit, 10))
            {
                WhenClickedOn(hit.collider.gameObject); //call WhenClickedOn gameObject
            }
            else {
                Debug.Log("MISS!"); //else debug "MISS!"
            }
        }
        
    }
    
    //Called when an gameObject with a collider is clicked on with a Raycast
    //notice, that's it is virtual, so can be overridden 
    public virtual void WhenClickedOn(GameObject go)
    {
        Debug.Log("You Clicked ON: " + go.name);
    }
}
