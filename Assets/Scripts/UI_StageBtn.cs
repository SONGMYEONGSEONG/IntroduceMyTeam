using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_StageBtn : MonoBehaviour
{
    [SerializeField] GameObject UnLockStageBtn;
    [SerializeField] GameObject LockStageBtn;
    [SerializeField] int stageNum;
    [SerializeField] Text StageLabel;

    public int StageNum { set { stageNum = value; } }

    private void Start()
    {
        StageLabel.text = "Stage" + stageNum.ToString();
    }

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

    public void BossStageStart()
    {
        DataManager.Instance.CurStage = stageNum;
        SceneManager.LoadScene("BossScene");
    }
}
