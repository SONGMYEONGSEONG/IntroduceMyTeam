using System.Collections;
using System.Linq;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    //public Texture2D frontImage;
    public SpriteRenderer frontSprite;

    void Start()
    {
        //frontImage = GetComponent<Texture2D>();
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

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else if(GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }

    public void DestroyCard()
    {
        Destroy(gameObject);
    }

    public void InvokeDestroyCard()
    {
        Invoke("DestroyCard", 0.3f);
    }

    public void CloseCard() //카드가 틀리다면 다시 뒤집는 함수
    {
        Invoke("CloseCardInvoke", 0.5f);
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
        //frontImage = Resources.Load<Texture2D>($"image_{idx}");
        frontSprite.sprite = Resources.Load<Sprite>($"image_{idx}");
    }
}
