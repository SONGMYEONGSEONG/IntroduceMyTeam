using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_Start : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnToBaseTitle()
    {
        SceneManager.LoadScene("TitleScene");
        AudioManager.instance.PlayBgm("bgmusic");
    }
}
