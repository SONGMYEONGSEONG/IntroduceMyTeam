using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 0.1f;


    void Update()
    {
        transform.position += Vector3.down * speed;
        if (transform.position.y < -6 || transform.position.x > 3.5 || transform.position.x < -3.5)
        {
            Destroy(gameObject);
        }
    }
    
}
