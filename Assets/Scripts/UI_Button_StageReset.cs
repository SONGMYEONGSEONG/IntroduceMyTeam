using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_StageReset : MonoBehaviour
{
    public void StageReset()
    {
        PlayerPrefs.SetInt("CurStage", 1);
        SceneManager.LoadScene("StageSelectScene");
    }
}
