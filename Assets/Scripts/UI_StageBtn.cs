using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StageBtn : MonoBehaviour
{
    public delegate void OnStageBtnClicked();
    public static event OnStageBtnClicked OnStageBtnClickedHandler;

    [SerializeField] GameObject UnLockStageBtn;
    [SerializeField] GameObject LockStageBtn;

    public void UnLock()
    {
        UnLockStageBtn.SetActive(true);
        LockStageBtn.SetActive(false);
    }

    //Test
    public void TestCode()
    {
        OnStageBtnClickedHandler.Invoke();
    }

    public void StageStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
