using System.Collections;
using System.Linq;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public Texture2D frontImage;

    void Start()
    {
        frontImage = GetComponent<Texture2D>();
    }

    void Update()
    {
        
    }

    public void InvokeOpenCard()
    {
        Invoke("OpenCard", 1.0f);
    }
    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        
        
        AudioManager.instance.PlaySFX("flip");

        GameManager.Instance.firstCard = null;
        GameManager.Instance.secondCard = null;
    }

    void DestroyCard()
    {
        Destroy(gameObject);
    }

    public void InvokeDestroyCard()
    {
        Invoke("DestroyCard", 1.0f);
    }

    public void CloseCard() //카드가 틀리다면 다시 뒤집는 함수
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void SetImage(int a)
    {
        idx = a+1;
        frontImage = Resources.Load<Texture2D>($"image_{idx}");
    }
}
