using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    List<UI_StageBtn> StageBtns; //Stage "Button" Container
    [SerializeField] GameObject parentsBtn; //버튼을 부모 오브젝트의 자식으로 선언하기 위해 만듬
    [SerializeField] UI_StageBtn stageButtonPrefeb; //버튼 Stage Prefebs
    [SerializeField] float yBtnPosGap = 200; //버튼 들의 간격

    float yBtnPos; //버튼이 배치되기 시작하는 좌표 
   
    public void Start()
    {
        StageBtns =new List<UI_StageBtn>();
        int StageCount = DataManager.Instance.Stages.Count; //DataManager에서 Stage 갯수를 받아옴

        /* Stage 갯수에 따라 Stgae버튼 배치를 하기 위한 로직 */

        //버튼의 배치 시작 좌표 세팅
        int index = Mathf.FloorToInt(StageCount * 0.5f);
        yBtnPos = yBtnPosGap * index;
        if (StageCount % 2 == 0) yBtnPos -= yBtnPosGap * 0.5f;

        //배치 시작
        for (int i = 0; i < StageCount; i++)
        {
            UI_StageBtn btns = Instantiate(stageButtonPrefeb, parentsBtn.transform); //버튼 생성
            btns.StageNum = DataManager.Instance.Stages[i].stageNum; //버튼의 value값 추가 , value = 해당 Stage의 넘버링

            Vector2 btnPos = new Vector2(0, yBtnPos - (i * yBtnPosGap)); //버튼의 최종 좌표
            btns.gameObject.GetComponent<RectTransform>().anchoredPosition = btnPos;//버튼 좌표 배치

            StageBtns.Add(btns);//생성한 버튼 오브젝트를 List에 추가
        }
        /* !Stage 갯수에 따라 Stgae버튼 배치를 하기 위한 로직! */

        //DataManager의 모든 Stage Data를 호출
        List<Stage> stageList = DataManager.Instance.Stages;

        StageBtns[0].UnLock(); // 1스테이지는 무조건 언락 되었어야하기때문에 

        //Stage Data를 확인하여 Stage 해금 시작
        for (int i =1; i < StageCount; i++) 
        {
            //전의 Stage가 클리어 되있으면 다음 Stage를 해금시킨다.
            if(stageList[i-1].isClear)
            {
                StageBtns[i].UnLock();
            }
        }

    }

}
