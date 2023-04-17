using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShield : MonoBehaviour
{
    public float shieldStrength = 50; //init shield strength

    public virtual float AdjustDamage(float damage){
        if(shieldStrength > damage){ //if there is more shield than damage
            shieldStrength -= damage; //reduce shield strength by damage
            return 0;   //player takes no damage, shield absorbed it all
        } else if(shieldStrength > 0){ //if there is not enough shield to absord all damage
            damage = damage - shieldStrength; //reduce damage amount
            shieldStrength = 0; //remove remaining shields
            return damage; //return remaining damage
        } else { //if shields are gone
            return damage; //return all the damage
        }
    }
}
