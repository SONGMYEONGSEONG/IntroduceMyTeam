using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fire;
    int hp = 3000;
    public Image hpBar;
    public Transform playerTransform;
    
    void Start()
    {
        StartCoroutine(coroutine());
    }

    void Update()
    {
        hpBar.transform.localScale = new Vector2(hp / 3000f, 1.0f);
        Hiddenstage.Instance.bossPos = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp -= 5;
        }
    }

    void ShotToPlayer()
    {
        Vector3 targetPos = playerTransform.position;
        Vector3 myPos = new Vector3(0f, 1.4f, 0);
        Vector3[] vectorToTarget = new Vector3[5];
        for (int i = 0; i < 5; i ++)
        {
            vectorToTarget[i] = new Vector3(targetPos.x - 2 + i, targetPos.y - myPos.y, targetPos.z - myPos.z).normalized;
        }

        for (int i = 0; i < 5; i ++)
        {
            GameObject Shot = Instantiate(bullet, myPos, Quaternion.identity);
            Shot.GetComponent<Rigidbody2D>().AddForce(vectorToTarget[i] * 150f);
        }
    }

    void ShootCircle()
    {
        Vector3 targetPos = playerTransform.position;
        Vector3 myPos = new Vector3(0f, 1.4f, 0f);
        Vector3 myPos_left = new Vector3(1.6f, 2f, 0f);
        Vector3 myPos_right = new Vector3(-1.6f, 2f, 0f);
        Vector3 vectorToTarget = (targetPos - myPos).normalized;
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                GameObject Shot = Instantiate(bullet, myPos_left, Quaternion.identity);
                Shot.GetComponent<Rigidbody2D>().AddForce(vectorToTarget * 60f);
            }
            else
            {
                GameObject Shot = Instantiate(bullet, myPos_right, Quaternion.identity);
                Shot.GetComponent<Rigidbody2D>().AddForce(vectorToTarget * 60f);
            }
        }
    }

    void MakeCircle()
    {
        Vector3 targetPos = playerTransform.position;
        Vector3 myPos = new Vector3(0f, 1.4f, 0);
        Vector3 vectorToTarget = (targetPos - myPos).normalized;
        int n = 30;

        for(int i = 0; i < n; i ++)
        {
            GameObject MakeCircle = Instantiate(bullet, myPos, Quaternion.identity);
            Vector2 circleVec = new Vector2(Mathf.Cos((Mathf.PI) * i / n ), Mathf.Sin(-(Mathf.PI) * i / n ));
            MakeCircle.GetComponent<Rigidbody2D>().AddForce(circleVec * 30f);
        }
        
    }

    IEnumerator coroutine()
    {
        while(true)
        {
            MakeCircle();

            for (int j = 0; j < 5; j++)
            {
                ShootCircle();
            }

            for (int i = 0; i < 10; i ++)
            {
                ShotToPlayer();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}