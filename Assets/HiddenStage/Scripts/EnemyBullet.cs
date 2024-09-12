using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y > 6 || transform.position.y < -6 ||
            transform.position.x > 3.5 || transform.position.x < -3.5 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            
        }
    }

}
