using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] Board board;
 
    [SerializeField] int firstIndex;
    [SerializeField] int secondIndex;

    bool isBossPlay = false;
    int seenIndex = -1;// ù��° ���� ī���� �ߺ� �ε��� üũ�� 
    List<GameObject> bossCards;
    bool cardSelectSequence = false;

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

    public void CardSelect(int Index)
    {
        do
        {
            Index = Random.Range(0, bossCards.Count);
        }
        while (board.Cards[Index] == null || seenIndex == Index);
        board.Cards[Index].GetComponent<Card>().BossOpenCard();

        switch (cardSelectSequence)
        {
            case true:
                seenIndex = -1;
                Debug.Log("�ι�° ī�� :" + board.Cards[Index].GetComponent<Card>().idx);
                break;
            case false:
                seenIndex = Index;
                Debug.Log("ù��° ī�� :" + board.Cards[Index].GetComponent<Card>().idx);
                break;
        }
        cardSelectSequence = !cardSelectSequence;
    }

    IEnumerator BossTurnPlay()
    {
        isBossPlay = true;

        yield return new WaitForSeconds(0.5f);

        CardSelect(firstIndex);
        yield return new WaitForSeconds(0.5f);
        CardSelect(secondIndex);
        yield return new WaitForSeconds(0.5f);

        isBossPlay = false;
    }

}
