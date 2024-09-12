using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hiddenstage : MonoBehaviour
{
    public static Hiddenstage Instance;
    public InputField hiddenKeyInput;
    public GameObject inputField;
    bool shown = false;
    public Vector3 playerPos;
    public Vector3 bossPos;

    private string getKey;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {

    }

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
