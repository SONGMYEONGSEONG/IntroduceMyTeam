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
    [SerializeField] Text clearTimeTxt;

    //Boss전 변수
    bool isBoss = false;
    bool isBossTurn = false; 
    [SerializeField] Boss boss;
    public bool IsBossTurn { get { return isBossTurn; } }
    int bossScore = 0;
    int playerScore = 0;
    [SerializeField] Text bossScoreTxt;
    [SerializeField] Text playerScoreTxt;

    [SerializeField] float totalTime = 30.0f;

    int cardCount;
    public int CardCount { set {cardCount =  value; } }

    bool isplayed = false;
    public bool IsPlayed { get { return isplayed; } set { isplayed = value; } }


    private void Start()
    {
        Time.timeScale = 1.0f;

        if (DataManager.Instance.GetCurStgae().isBoss)
        {
            isBoss = true;
            isBossTurn = true;
            timerPrint.gameObject.SetActive(false);
            clearTimeTxt.gameObject.SetActive(false);
            boss.gameObject.SetActive(true);
            bossScoreTxt.gameObject.SetActive(true);
            playerScoreTxt.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        //일반게임
        if (isplayed && !isBoss)
        {
            if (totalTime <= 0)
            {
                Invoke("GameOver", 0.1f);
            }

            totalTime -= Time.deltaTime;
            timerPrint.PrintTimer(totalTime);
        }

        //보스전
        if(isplayed && isBoss)
        {
            switch(isBossTurn)
            {
                case true: //Boss Turn 진행
                    if (firstCard == null && secondCard == null)
                    {
                        boss.BossPlay();
                    }
                    break;

                case false: //플레이어 턴 

                    break; 
            }
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

            if (isBoss)
            {
                switch(isBossTurn)
                {
                    case true:
                        bossScore++;
                        bossScoreTxt.text = bossScore.ToString();
                        break;

                    case false:
                        playerScore++;
                        playerScoreTxt.text = playerScore.ToString();
                        break;
                }
            }
            
            if (cardCount == 0)
            {
                DataManager.Instance.SetCurStgaeIsClear();
                clearTimeTxt.text = totalTime.ToString("N2");
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

        if (isBoss)
        {
            isBossTurn = !isBossTurn; //턴 교체
        }
    }


}