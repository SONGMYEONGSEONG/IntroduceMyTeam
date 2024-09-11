using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StageBtn : MonoBehaviour
{
    [SerializeField] GameObject UnLockStageBtn;
    [SerializeField] GameObject LockStageBtn;
    [SerializeField] int stageNum;

    public void UnLock()
    {
        UnLockStageBtn.SetActive(true);
        LockStageBtn.SetActive(false);
    }

    public void StageStart()
    {
        DataManager.Instance.CurStage = stageNum;
        SceneManager.LoadScene("MainScene");
    }
}
