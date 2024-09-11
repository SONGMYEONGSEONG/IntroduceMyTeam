using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_StageClear : MonoBehaviour
{
    public void StageClearSceneLoad()
    {

        SceneManager.LoadScene("StageSelectScene");
    }
}
