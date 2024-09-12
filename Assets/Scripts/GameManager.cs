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
    [SerializeField] Text ClearTimeLabelTxt;
    [SerializeField] Text clearTimeTxt;
    [SerializeField] GameObject addTimeText;

    //Boss�� ����
    bool isBoss = false;
    bool isBossTurn = false; 
    [SerializeField] Boss boss;
    public bool IsBossTurn { get { return isBossTurn; } }
    public int bossScore = 0;
    int playerScore = 0;
    [SerializeField] float PlayerTurnTime = 5.0f;
    [SerializeField] Text bossScoreTxt;
    [SerializeField] Text playerScoreTxt;
    [SerializeField] UI_BossBattleTimer bossBattleTimer;
    [SerializeField] Text bossTurn;
    //

    [SerializeField] float totalTime = 30.0f;

    int cardCount;
    public int CardCount { set {cardCount =  value; } }

    bool isplayed = false;
    public bool IsPlayed { get { return isplayed; } set { isplayed = value; } }


    private void Start()
    {
        Time.timeScale = 1.0f;
        totalTime = 30.0f;

        if (DataManager.Instance.GetCurStgae().isBoss)
        {
            isBoss = true;
            isBossTurn = true;
            timerPrint.gameObject.SetActive(false);
            clearTimeTxt.gameObject.SetActive(false);
            boss.gameObject.SetActive(true);
            bossScoreTxt.gameObject.SetActive(true);
            playerScoreTxt.gameObject.SetActive(true);
            totalTime = PlayerTurnTime;
        }
    }

    private void Update()
    {
        //�Ϲݰ���
        if (isplayed && !isBoss)
        {
            if (totalTime <= 0)
            {
                Invoke("GameOver", 0.1f);
            }

            totalTime -= Time.deltaTime;
            timerPrint.PrintTimer(totalTime);
        }

        //������
        if(isplayed && isBoss)
        {
            switch (isBossTurn)
            {
                case true: //Boss Turn ����
                    bossTurn.gameObject.SetActive(true);
                    bossBattleTimer.gameObject.SetActive(false);

                    if (firstCard == null && secondCard == null)
                    {
                        boss.BossPlay();
                    }
                    break;

                case false: //�÷��̾� �� 
                    bossTurn.gameObject.SetActive(false);
                    bossBattleTimer.gameObject.SetActive(true);

                    totalTime -= Time.deltaTime;
                    bossBattleTimer.PrintTimerBar(totalTime, PlayerTurnTime);

                    if (totalTime <= 0)
                    {
                        CardReset();
                        isBossTurn = !isBossTurn; //�� ��ü
                        totalTime = PlayerTurnTime;
                    }
                    break; 
            }
        }
    }

    private void OffUI()
    {
        timerPrint.gameObject.SetActive(false);
        bossScoreTxt.gameObject.SetActive(false);
        playerScoreTxt.gameObject.SetActive(false);
        bossBattleTimer.gameObject.SetActive(false);

        if(isBoss)
        {
            ClearTimeLabelTxt.gameObject.SetActive(false);
            clearTimeTxt.gameObject.SetActive(false);
        }
    }

    private void CardReset()
    {
        if (firstCard != null)
        {
            firstCard.CloseCard();
            firstCard = null;
        }

        if(secondCard != null)
        {
            secondCard.CloseCard();
            secondCard = null;
        }
    }

    private void GameOver()
    {
        OffUI();
        isplayed = false;
        timerPrint.PrintTimer(0.0f);
        gameOverPopUp.gameObject.SetActive(true);
        Invoke("TimeStop", 1.0f);
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            AudioManager.Instance.PlaySFX("match");

            //�ı�
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
            else
            {
                totalTime += 5.0f;
                //timer.GetComponent<UI_Timer_print>().AddTime(5);
                addTimeText.GetComponent<TextFade>().StartFadeToZero();
            }
            
            if (cardCount == 0)
            {
                OffUI();
                isplayed = false;
                switch (isBoss)
                {
                    case true:

                        if(playerScore > bossScore)
                        {
                            gameClearPopUp.gameObject.SetActive(true);
                            DataManager.Instance.SetCurStgaeIsClear();
                        }
                        else
                        {
                            gameOverPopUp.gameObject.SetActive(true);
                        }
                        break;

                    case false:
                        DataManager.Instance.SetCurStgaeIsClear();
                        clearTimeTxt.text = totalTime.ToString("N2");
                        gameClearPopUp.gameObject.SetActive(true);
                        break;
                }
                Invoke("TimeStop", 1.0f);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();  
        }

        //���� ������ �ʱ�ȭ
        firstCard = null;
        secondCard = null;

        if (isBoss)
        {
            isBossTurn = !isBossTurn; //�� ��ü
            totalTime = PlayerTurnTime;
        }

        
    }

    private void TimeStop()
    {
        Time.timeScale = 0.0f;
    }

}