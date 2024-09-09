using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer_print : MonoBehaviour
{
    [SerializeField] Text timerTxt;
    [SerializeField] float time = 30.0f;

    private void Update()
    {
        if (time > 0) time -= Time.deltaTime;
        else time = 0;

        timerTxt.text = time.ToString("N2");   
    }
}
