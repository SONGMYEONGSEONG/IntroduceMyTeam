using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    [SerializeField] Board board;

    [SerializeField] int firstIndex;
    [SerializeField] int secondIndex;

    bool isBossPlay = false;
    List<GameObject> bossCards;
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
        while (board.Cards[Index] == null);
        board.Cards[Index].GetComponent<Card>().OpenCard();
    }

    IEnumerator BossTurnPlay()
    {
        isBossPlay = true;

        CardSelect(firstIndex);
        yield return new WaitForSeconds(0.1f);
        CardSelect(secondIndex);
        yield return new WaitForSeconds(0.2f);

        isBossPlay = false;
    }

}
