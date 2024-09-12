using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Board SIze")]
    [SerializeField] float xAdjustment  = -2.0f;
    [SerializeField] float yAdjustment  = -3.0f;
    [SerializeField] float xGap         = 1.4f;
    [SerializeField] float yGap         = 1.4f;

    public float XAdjustment { set { xAdjustment = value; } }
    public float YAdjustment { set { yAdjustment = value; } }
    public float XGap { set { xGap = value; } }
    public float YGap { set { yGap = value; } }

    [Header("Card")]
    [SerializeField] GameObject cardPrefeb;

    List<GameObject> cards;
    int allCardNum;

    public List<GameObject> Cards { get { return cards; } }
    public int AllCardNum { get { return allCardNum; } }

    Vector2[] arrPos;

    // Start is called before the first frame update
    void Start()
    {
        Stage curStageData = DataManager.Instance.GetCurStgae();

        allCardNum = curStageData.boardWidth * curStageData.boardHeight;
        GameManager.Instance.CardCount = allCardNum;

        arrPos = new Vector2[allCardNum];
        cards = new List<GameObject>();

        int[] arr = new int[allCardNum];
        int halfCardNum = (int)(allCardNum * 0.5f);

        int index = 0;
        for (int i = 0; i < allCardNum; i += 2, index++)
        {
            arr[i] = index;
            arr[i+1] = index;
        }

        float randomMax = halfCardNum - 1;

        arr = arr.OrderBy(x => Random.Range(0f, randomMax)).ToArray();
   
        for (int i = 0; i < curStageData.boardHeight ; i++)
        {
            for (int j = 0; j < curStageData.boardWidth ; j++)
            {
                GameObject gameObject = Instantiate(cardPrefeb, new Vector2(0,-5),Quaternion.identity);

                //���� �迭 ���� ���� �տ� �ִ� ���� value���� ��������
                //Skip�� �̿��ؼ� ���� �տ� �ִ� ���Ҹ� ���� �� arr�� �ٽ� �����ϴ� �Լ�
                int temp = arr[0];
                arr = arr.Skip(1).ToArray();

                gameObject.GetComponent<Card>().SetImage(temp);

                Vector2 pos = new Vector2(j * xGap + xAdjustment, i * yGap + yAdjustment);
                arrPos[(curStageData.boardWidth * i) + j] = pos;

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
