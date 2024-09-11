using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Board : MonoBehaviour
{
    int width = 4;
    [SerializeField] int height= 4;

    [SerializeField] float xAdjustment = -2.0f;
    [SerializeField] float yAdjustment = -3.0f;
    [SerializeField] float xGap = 1.4f;
    [SerializeField] float yGap = 1.4f;

    [SerializeField] GameObject card;
    Vector2[] arrPos;

    List<GameObject> cards;

    // Start is called before the first frame update
    void Start()
    {
        arrPos = new Vector2[height * width];
        cards = new List<GameObject>();

        int[] arr = new int[height * width];
        int CardHalf = (int)(height * width *0.5f);
        for (int i = 0; i < CardHalf; i += 2)
        {
            arr[i] = i;
            arr[i+1] = i;
        }

        float RandomMax = CardHalf - 1;

        arr = arr.OrderBy(x => Random.Range(0f, RandomMax)).ToArray();
   
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject gameObject = Instantiate(card,new Vector2(0,-5),Quaternion.identity);

                //���� �迭 ���� ���� �տ� �ִ� ���� value���� ��������
                //Skip�� �̿��ؼ� ���� �տ� �ִ� ���Ҹ� ���� �� arr�� �ٽ� �����ϴ� �Լ�
                int temp = arr[0];
                arr = arr.Skip(1).ToArray();

                gameObject.GetComponent<Card>().SetImage(temp);

                Vector2 pos = new Vector2(j * xGap + xAdjustment, i * yGap + yAdjustment);
                arrPos[(width * i) + j] = pos;

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
