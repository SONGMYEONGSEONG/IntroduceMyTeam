using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Animator anim;
    public GameObject gameoverUI;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(MakeBullet(anim.GetBool("isHit")));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float posX = mousepos.x;
        float posY = -3.0f;
        if (posX > 2.7) posX = 2.7f;
        if (posX < -2.7) posX = -2.7f;

        if (anim.GetBool("isHit") == true)
        {
            Vector3 shipPos = this.transform.position;
            transform.position = shipPos;
            Hiddenstage.Instance.playerPos = shipPos;
            Invoke("GameOver", 1.0f);
        }
        else
        {
            Vector3 shipPos = new Vector2(posX, posY);
            transform.position = shipPos;
            Hiddenstage.Instance.playerPos = shipPos;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            anim.SetBool("isHit", true);
            AudioManager.instance.StopBgm();
        }
    }

    IEnumerator MakeBullet(bool _false)
    {
        while(_false == false)
        {
            AudioManager.Instance.PlaySFX("shoot");
            float x = transform.position.x;
            float y = transform.position.y;
            Instantiate(BulletPrefab, new Vector2(x, y), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(false);
        gameoverUI.gameObject.SetActive(true);
    }
}
