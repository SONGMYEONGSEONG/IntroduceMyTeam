using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] List<UI_StageBtn> StageBtns;

    public void Start()
    {
        List<Stage> stageList = DataManager.Instance.Stages;

        StageBtns[0].UnLock(); // 1���������� ������ ��� �Ǿ�����ϱ⶧���� 

        for (int i =1; i < StageBtns.Count; i++) 
        {
            if(stageList[i-1].isClear)
            {
                StageBtns[i].UnLock();
            }
        }

    }

}
