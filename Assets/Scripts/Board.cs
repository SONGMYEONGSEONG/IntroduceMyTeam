using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Board : MonoBehaviour
{
    [SerializeField] int col = 4;
    [SerializeField] int row = 4;

    [SerializeField] float xAdjustment = -2.0f;
    [SerializeField] float yAdjustment = -3.0f;

    [SerializeField] GameObject card;
    Vector2[] arrPos;

    List<GameObject> cards;

    // Start is called before the first frame update
    void Start()
    {
        /// 스테이지 선택을 위한 카드 자동화 진행중 
        cards = new List<GameObject> ();
        arrPos = new Vector2[ col * row ];

        if (col * row % 2 != 0)
        {
            Debug.Log("행과 열이 짝수가 아닙니다. 게임이 성립되지 않습니다.");
            return;
        }

        List<int> list_Index = new List<int> ();
        for(int i = 0; i < col * row *0.5f; i++)
        {
            list_Index.Add(i);
            list_Index.Add(i);
        }
        ///

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();
   
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject gameObject = Instantiate(card,new Vector2(0,-5),Quaternion.identity);

                int temp = arr[0];
                arr = arr.Skip(1).ToArray();

                gameObject.GetComponent<Card>().SetImage(temp);

                Vector2 pos = new Vector2(j * 1.4f + xAdjustment, i * 1.4f + yAdjustment);
                arrPos[(4 * i) + j] = pos;

                cards.Add(gameObject);
            }
        }

        StartCoroutine(AllMoveCard());     
    }

    IEnumerator AllMoveCard()
    {
        for (int i = 0; i < arrPos.Length; i++)
        {
            cards[i].GetComponent<Card>().MoveCard(arrPos[i]);

            yield return new WaitForSeconds(0.1f);
        }
    }

}
