using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SountTestButtons : MonoBehaviour
{
    public void TestPlayBgm()
    {
        AudioManager.instance.PlayBgm("bgmusic");
        
    }

    public void TestStopBgm()
    {
        AudioManager.instance.StopBgm();
    }

    public void TestPlaySFX1()
    {
        AudioManager.instance.PlaySFX("flip");
    }

    public void TestPlaySFX2()
    {
        AudioManager.instance.PlaySFX("match");
    }
}
