using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] List<UI_StageBtn> StageBtns;

    public void Start()
    {
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
