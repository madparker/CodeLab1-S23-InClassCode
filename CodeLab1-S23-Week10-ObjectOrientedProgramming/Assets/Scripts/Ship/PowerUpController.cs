using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public ShipControl shipControl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //change to BaseShield
        {
            Destroy(shipControl.shield);
            gameObject.AddComponent<BaseShield>();
        }
    }
}
