using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class BossFace : MonoBehaviour
{
    [SerializeField] Board board;

    bool isBossPlay = false;
    int seenIndex = -1;// 첫번째 뽑은 카드의 중복 인덱스 체크용 
    List<GameObject> bossCards;
    bool cardSelectSequence = false;

    [SerializeField] Card firstSelectCard;
    [SerializeField] Card memory;

    private void Start()
    {
        bossCards = board.Cards;

    }

    public void BossPlay()
    {
        if (!isBossPlay)
        {
           StartCoroutine(BossTurnPlay());
        }   
    }

    public void CardSelect()
    {
        int Index;

        do
        {
            Index = UnityEngine.Random.Range(0, bossCards.Count);
        }
        while (board.Cards[Index] == null || seenIndex == Index);

        switch (cardSelectSequence)
        {
            case true:
                seenIndex = -1;
                Debug.Log("두번째 카드 :" + board.Cards[Index].GetComponent<Card>().idx);
                break;
            case false: 
                seenIndex = Index;
                Debug.Log("첫번째 카드 :" + board.Cards[Index].GetComponent<Card>().idx);
                break;
        }
        cardSelectSequence = !cardSelectSequence;

        board.Cards[Index].GetComponent<Card>().BossOpenCard();
    }


    IEnumerator BossTurnPlay()
    {
        isBossPlay = true;

        yield return new WaitForSeconds(0.5f);

        CardSelect();
        yield return new WaitForSeconds(0.5f);
        CardSelect();
        yield return new WaitForSeconds(0.5f);

        isBossPlay = false;
    }

}
