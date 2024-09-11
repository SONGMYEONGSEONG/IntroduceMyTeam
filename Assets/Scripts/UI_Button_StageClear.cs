using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_StageClear : MonoBehaviour
{
    public void StageClearSceneLoad()
    {
        int curStage = PlayerPrefs.GetInt("CurStage", 1);
        PlayerPrefs.SetInt("CurStage", curStage + 1);
        SceneManager.LoadScene("StageSelectScene");
    }
}
