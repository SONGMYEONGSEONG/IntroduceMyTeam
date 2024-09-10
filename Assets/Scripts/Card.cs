using System.Collections;
using System.Linq;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontSprite;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenCard()
    {
        Debug.Log("열림");
        Invoke("OpenCard", 1.0f);
    }
    public void InvokeOpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        AudioManager.instance.PlaySFX("flip");
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else if (GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }

    void InvokeDestroyCard()
    {
        Destroy(gameObject);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void DestroyCard()
    {
        Invoke("DestroyCard", 1.0f);
    }

    public void CloseCard() //카드가 틀리다면 다시 뒤집는 함수
    {
        Invoke("CloseCardInvoke", 1.0f);
    }


    public void SetImage(int a)
    {
        idx = a + 1;
        RectTransform rect = (RectTransform)frontSprite.transform;
        frontSprite.sprite = Resources.Load<Sprite>($"image_{idx}");
        rect.sizeDelta = new Vector2(1, 1);
    }
}
