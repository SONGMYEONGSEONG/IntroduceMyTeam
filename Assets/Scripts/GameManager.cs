using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public Card firstCard;
    public Card secondCard;

    [SerializeField] UI_Timer_print timerPrint;
    [SerializeField] GameObject gameClearPopUp;
    [SerializeField] GameObject gameOverPopUp;
    public int cardCount = 16;
    [SerializeField] float totalTime = 30.0f;

    bool isplayed = true;

    private void Start()
    {
        AudioManager.Instance.PlayBgm("bgmusic");
        Time.timeScale = 1.0f;
        isplayed = true;
    }

    private void Update()
    {
        if (isplayed)
        {
            if (totalTime <= 0)
            {
                Invoke("GameOver", 0.1f);
            }

            totalTime -= Time.deltaTime;
            timerPrint.PrintTimer(totalTime);
        }
    }

    private void GameOver()
    {
        timerPrint.PrintTimer(0.0f);
        gameOverPopUp.gameObject.SetActive(true);
        isplayed = false;
        Time.timeScale = 0.0f;
    }

    

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            AudioManager.Instance.PlaySFX("match");

            //파괴
            firstCard.InvokeDestroyCard();
            secondCard.InvokeDestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                gameClearPopUp.gameObject.SetActive(true);
                isplayed = false;
                Time.timeScale = 0.0f;

            }
        }

        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        //기존 데이터 초기화
        firstCard = null;
        secondCard = null;
    }
}