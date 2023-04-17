using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public virtual void Attack()
    {
        Vector2 currentPos = transform.position;
        currentPos.y += 1f;
        
        SpawnBullet(currentPos);
    }

    public virtual void SpawnBullet(Vector2 currentPos)
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);

        bullet.GetComponent<Rigidbody2D>().gravityScale = -1;
        
        bullet.transform.position = currentPos;
    }
}
