using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Card firstCard;
    public Card secondCard;

    public GameObject timer;
    public GameObject addTimeText;

    public int cardCount;

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

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            timer.GetComponent<UI_Timer_print>().AddTime(5);
            addTimeText.GetComponent<TextFade>().StartFadeToZero();

            cardCount -= 2;

            if (cardCount == 0)
            {
                GameOver();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    public void GameOver()
    {

    }
}

