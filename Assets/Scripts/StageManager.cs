using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] List<UI_StageBtn> StageBtns;

    int CurUnLockStage = 1;

    public void Start()
    {
        StageBtns[CurUnLockStage -1].UnLock();
        UI_StageBtn.OnStageBtnClickedHandler += UnLockStage;
    }

    public void UnLockStage()
    {
        if (StageBtns.Count <= CurUnLockStage) return;

        CurUnLockStage++;
        StageBtns[CurUnLockStage - 1].UnLock();
    }

}
