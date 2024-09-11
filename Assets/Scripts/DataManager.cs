using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager가 해당 게임의 대한 Data값을 저장해야되는데
//DataManager가 그역할을 대신하고 MainScene의 게임에 대란 로직을 관리하는것으로 대체

[System.Serializable]
public struct Stage
{
    public int stageNum;
    public int boardWidth;
    public int boardHeight;
    public bool isClear;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance.GetComponent<DataManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(DataManager).Name;
                    instance = obj.AddComponent<DataManager>();
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

    [SerializeField] private List<Stage> stages;
    private int curStage;

    public List<Stage> Stages { get { return stages; } }
    public int CurStage { set { curStage = value - 1; } }


    public Stage GetCurStgae()
    {
        return stages[curStage];
    }

    public void SetCurStgaeIsClear()
    {
        Stage stage = stages[curStage];
        stage.isClear = true;
        stages[curStage] = stage;
    }
}
