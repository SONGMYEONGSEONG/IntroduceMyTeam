using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_BossBattleTimer : MonoBehaviour
{
    [SerializeField] RectTransform front;

    public void PrintTimerBar(float Time, float bossBattleTime)
    {
        front.localScale = new Vector3(Time / bossBattleTime, 1f, 1f);
    }
}
