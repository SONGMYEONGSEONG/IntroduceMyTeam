using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public GameObject firstCard;
    public GameObject secondCard;

    private void Update()
    {
    }

}
