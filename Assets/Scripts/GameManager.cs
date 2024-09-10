using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Card firstCard;
    public Card secondCard;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
    }



    private void Update()
    {
        
    }

    public void Matched() //ī�尡 ��ġ�ϴ��� Ȯ�� �ϴ� �Լ�
    {
        if (firstCard.idx == secondCard.idx) //ī�尡 ���ٸ�
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else //ī�尡 Ʋ���ٸ�
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null; //������Ʈ �� �ʱ�ȭ
        secondCard = null;
    }
}

