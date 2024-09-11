using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hiddenstage : MonoBehaviour
{
    public InputField hiddenKeyInput;
    public GameObject inputField;
    bool shown = false;

    private string getKey;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputField.SetActive(!shown);
            Time.timeScale = 0.0f;
            getKey = hiddenKeyInput.text;
        }
        
    }


    public void SceneChange()
    {
        if (hiddenKeyInput.text == "SpaceShooter")
        {
            SceneManager.LoadScene("HiddenStageTitle");
            AudioManager.instance.StopBgm();
            AudioManager.instance.PlayBgm("adventure8bit");
            Time.timeScale = 1.0f;
        }
    }

    public void CancelHiddenConsole()
    {
        Time.timeScale = 1.0f;
        inputField.SetActive(false);
    }
    
}
