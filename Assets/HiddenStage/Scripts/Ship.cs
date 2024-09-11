using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        InvokeRepeating("MakeBullet",0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float posX = mousepos.x;
        float posY = -3.0f;
        if (posX > 2.7) posX = 2.7f;
        if (posX < -2.7) posX = -2.7f;

        transform.position = new Vector2(posX, posY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("피격당함");
            anim.SetBool("isHit", true);
        }
    }

    void MakeBullet()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(BulletPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
