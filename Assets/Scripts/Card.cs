using System.Collections;
using System.Linq;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;

    void Start()
    {
        
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

    public void DestroyCard()
    {
        Destroy(gameObject);
    }

    public void InvokeDestroyCard()
    {
        Invoke("DestroyCard", 1.0f);
    }

    public void CloseCard() //ī�尡 Ʋ���ٸ� �ٽ� ������ �Լ�
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
