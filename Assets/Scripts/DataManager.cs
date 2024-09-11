using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager�� �ش� ������ ���� Data���� �����ؾߵǴµ�
//DataManager�� �׿����� ����ϰ� MainScene�� ���ӿ� ��� ������ �����ϴ°����� ��ü

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
