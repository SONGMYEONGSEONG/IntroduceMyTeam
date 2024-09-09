using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_Start : MonoBehaviour
{
    public void GameStart()
    {
        Debug.Log("버튼클릭");
        SceneManager.LoadScene("MainScene");
    }
}
