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

    public void Matched() //카드가 일치하는지 확인 하는 함수
    {
        if (firstCard.idx == secondCard.idx) //카드가 같다면
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else //카드가 틀리다면
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null; //오브젝트 값 초기화
        secondCard = null;
    }
}

