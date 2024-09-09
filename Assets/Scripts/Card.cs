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

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        
    }

    public void DestroyCard()
    {
        Destroy(this);
    }

    public void InvokeDestroyCard()
    {
        Invoke("DestroyCard", 1.0f);
    }

    public void CloseCard() //카드가 틀리다면 다시 뒤집는 함수
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
