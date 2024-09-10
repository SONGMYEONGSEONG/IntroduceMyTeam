using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{

    public float xAdjustment = -2.0f;
    public float yAdjustment = -3.0f;

    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Vector2 pos = new Vector2(j * 1.4f + xAdjustment, i * 1.4f + yAdjustment);

                GameObject gameObject = Instantiate(card);
                gameObject.transform.position = pos;
                //gameObject.GetComponent<Card>().Setting(arr[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
