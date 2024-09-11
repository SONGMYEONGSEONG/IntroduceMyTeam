using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance.GetComponent<AudioManager>();
                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(AudioManager).Name;
                    instance = obj.AddComponent<AudioManager>();
                }
            }

            DontDestroyOnLoad(instance);
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource sfxPlayer;

    [SerializeField] AudioClip[] bgm;
    [SerializeField] AudioClip[] sfx;

    private void Start()
    {
         PlayBgm("bgmusic");
    }

    public void PlayBgm(string bgmName)
   {
        for(int i =0; i < bgm.Length; i++)
        {
            if (bgm[i].name == bgmName)
            {
                bgmPlayer.clip = bgm[i];
                bgmPlayer.Play();
                return;
            }
        }
   }

    public void StopBgm()
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = null;
    }

    public void PlaySFX(string sfxName)
    {
        for(int i = 0; i < sfx.Length ; i++)
        {
            if (sfx[i].name == sfxName)
            {
                sfxPlayer.clip = sfx[i];
                sfxPlayer.PlayOneShot(sfx[i]);
                return;
            }
        }
        sfxPlayer.clip = null;
    }
}
