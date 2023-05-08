using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

//https://gamedevbeginner.com/raycasts-in-unity-made-easy/

public class BasicRayCasting : MonoBehaviour
{
    bool debugMode = true; //bool for whether not to execute debug code
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (debugMode) //bool for whether not to execute debug code
        {
            //create a ray from this position to the "forward" of this position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //draw a ray (in sceneview) 
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);
        }

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) //simple raycast
            //if (Physics.Raycast(ray, out hit, 10)) //on gets colliders 10 units or less away
            
            // more detailed Raycast, for more info: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
            //if (Physics.Raycast(ray.origin, ray.direction, out  hit, 10, GetLayerMask(3), QueryTriggerInteraction.Ignore))
            
            //Sphere cast, similar to RayCast, but a more forgiving
            //if (Physics.SphereCast(ray.origin, 1, ray.direction, out hit, 10))
            {
                WhenClickedOn(hit.collider.gameObject);
            }
            else {
                Debug.Log("MISS!");
            }
        }
    }
    
    //Called when an gameObject with a collider is clicked on with a Raycast
    //notice, that's it is virtual, so can be overridden 
    public virtual void WhenClickedOn(GameObject go)
    {
        Debug.Log("You Clicked ON: " + go.name);
    }

    
    public int GetLayerMask(int layer, bool ignoreLayer = false)
    {
        int result = 1 << layer; //3 => 1000 (8) 

        if (ignoreLayer)
        {
            result = ~result; //invert binary
        }

        Debug.Log(result);

        return result;
    }
}
