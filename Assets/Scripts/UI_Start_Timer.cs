using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Start_Timer : MonoBehaviour
{
    [SerializeField] List<Text> texts;

    float elispedTime = 0.0f;
    int index = 0;

    private void Update()
    {
        elispedTime += Time.deltaTime;
        if(elispedTime >= 1.0f)
        {
            elispedTime = 0.0f;

            if (index < texts.Count)
            {
                texts[index].gameObject.SetActive(true);
                index++;
            }

            if (index >= texts.Count)
            {
                GameManager.Instance.IsPlayed = true;
                Destroy(gameObject);
            }
        }  
    }
}
