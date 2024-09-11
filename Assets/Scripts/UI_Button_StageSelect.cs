using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_StageSelect : MonoBehaviour
{
    public void StageSelectSceneLoad ()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
