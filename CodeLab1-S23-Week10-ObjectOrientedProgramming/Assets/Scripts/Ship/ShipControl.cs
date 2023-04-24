using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;

    public float forceMod = 10;

    Rigidbody2D rb2d;

    public float health = 100;
    public TextMesh healthText;

    public BaseAttack attack;
    public BaseShield shield;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shield = GetComponent<BaseShield>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = GetComponent<BaseAttack>();

            if (attack != null)
            {
                attack.Attack();
            }
        }

        if(Input.GetKey(leftKey)){ //move left
            rb2d.AddForce(Vector2.left * forceMod);
        }

        if (Input.GetKey(rightKey)){ //move right
            rb2d.AddForce(Vector2.right * forceMod);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject); //destroy the bullet
        TakeDamage(20); //call take damage
    }

    public void TakeDamage(float damageAmt)
    {

        shield = GetComponent<BaseShield>();
        
        if (shield != null) // if you have a shield
        {
            damageAmt = shield.AdjustDamage(damageAmt); //adjust the damage by the sheild amount

        }

        health -= damageAmt; //reduce helath by damage
        healthText.text = "Health: " + health; //update health display

        if (shield != null) // if you have a shield
        {
            healthText.text += "\nShield: " + shield.ToString(); //update health display to show shield name
        }
    }
}
