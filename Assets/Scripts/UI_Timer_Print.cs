using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer_print : MonoBehaviour
{
    [SerializeField] Text timerTxt;

    public void PrintTimer(float time)
    {
        timerTxt.text = time.ToString("N2");
    }

}
