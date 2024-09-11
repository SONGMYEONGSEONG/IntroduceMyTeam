using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fire;
    int hp = 3000;
    public Image hpBar;
    public Transform playerTransform;
    public Vector3 playerPos;
    public Vector3 bossPos;
    
    void Start()
    {
        StartCoroutine(coroutine(5, fire, playerPos, bossPos));
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.transform.localScale = new Vector2(hp / 3000f, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp -= 5;
        }
    }

    void ShotToPlayer(GameObject bullet, Vector3 _playerPos, Vector3 _bossPos)
    {
        Vector3 playerPos = _playerPos;
        Vector3 bossPos = _bossPos;
        GameObject bulletToPlayer = Instantiate(bullet, new Vector2(bossPos.x, bossPos.y), Quaternion.LookRotation(playerPos));
        Vector2 toPlayer = new Vector2(playerPos.x - bossPos.x, playerPos.y - bossPos.y);
        bulletToPlayer.GetComponent<Rigidbody2D>().AddForce(toPlayer * 10);
    }

    void ShootCircle(GameObject bullet, Vector3 _playerPos, Vector3 _bossPos)
    {
        Vector3 playerPos = _playerPos;
        Vector3 bossPos = _bossPos;
        GameObject normalAttack = Instantiate(bullet, new Vector2(transform.position.x + 0.8f, transform.position.y - 0.25f), Quaternion.identity);
        normalAttack.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 30f);

        Debug.Log("평타 발사중");
    }

    void MakeCircle(GameObject bullet, Vector3 _playerPos, Vector3 _bossPos)
    {
        Vector3 bossPos = _bossPos;
            GameObject MakeCircle = Instantiate(bullet, new Vector2(bossPos.x, bossPos.y - 0.55f), Quaternion.Euler(0, 0, (360 * 1 / (30 - 1)) + 180));
            Vector2 dirPos = new Vector2(Mathf.Cos((Mathf.PI) * 1 / (30 - 1)), Mathf.Sin((Mathf.PI) * 1) / (30 - 1));
            MakeCircle.GetComponent<Rigidbody2D>().AddForce(dirPos * 10f);
    }

    IEnumerator coroutine(float i, GameObject bullet, Vector3 _playerPos, Vector3 _bossPos)
    {
            yield return new WaitForSeconds(i);
            MakeCircle(bullet, _playerPos, _bossPos);
    }

}
