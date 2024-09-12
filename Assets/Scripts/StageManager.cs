using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    List<UI_StageBtn> StageBtns;
    [SerializeField] GameObject parentsBtn;
    [SerializeField] UI_StageBtn stageButtonPrefeb;
    [SerializeField] float yBtnPosGap = 200;

    float yBtnPos;
   
    public void Start()
    {
        StageBtns =new List<UI_StageBtn>();
        int StageCount = DataManager.Instance.Stages.Count;

        int index = Mathf.FloorToInt(StageCount * 0.5f);
        yBtnPos = yBtnPosGap * index;

        if (StageCount % 2 == 0) yBtnPos -= yBtnPosGap * 0.5f;


        for (int i = 0; i < StageCount; i++)
        {
            UI_StageBtn btns = Instantiate(stageButtonPrefeb, parentsBtn.transform);
            btns.StageNum = DataManager.Instance.Stages[i].stageNum;
            btns.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, yBtnPos -(i * yBtnPosGap) );

            StageBtns.Add(btns);
        }


        List<Stage> stageList = DataManager.Instance.Stages;

       StageBtns[0].UnLock(); // 1스테이지는 무조건 언락 되었어야하기때문에 

        for (int i =1; i < StageBtns.Count; i++) 
        {
            if(stageList[i-1].isClear)
            {
                StageBtns[i].UnLock();
            }
        }

    }

}
