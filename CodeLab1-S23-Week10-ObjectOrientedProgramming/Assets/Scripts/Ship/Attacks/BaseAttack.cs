using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{

    public GameObject bulletPrefab;
    
    public virtual void Attack()
    {
        Vector2 currentPos = transform.position;

        currentPos.y += 1;
        
        SpawnBullet(currentPos);
    }

    public virtual void SpawnBullet(Vector2 pos)
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);

        bullet.GetComponent<Rigidbody2D>().gravityScale = -1;

        bullet.transform.position = pos;
    }

}
