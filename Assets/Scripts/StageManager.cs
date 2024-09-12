using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    List<UI_StageBtn> StageBtns; //Stage "Button" Container
    [SerializeField] GameObject parentsBtn; //��ư�� �θ� ������Ʈ�� �ڽ����� �����ϱ� ���� ����
    [SerializeField] UI_StageBtn stageButtonPrefeb; //��ư Stage Prefebs
    [SerializeField] float yBtnPosGap = 200; //��ư ���� ����

    float yBtnPos; //��ư�� ��ġ�Ǳ� �����ϴ� ��ǥ 
   
    public void Start()
    {
        StageBtns =new List<UI_StageBtn>();
        int StageCount = DataManager.Instance.Stages.Count; //DataManager���� Stage ������ �޾ƿ�

        /* Stage ������ ���� Stgae��ư ��ġ�� �ϱ� ���� ���� */

        //��ư�� ��ġ ���� ��ǥ ����
        int index = Mathf.FloorToInt(StageCount * 0.5f);
        yBtnPos = yBtnPosGap * index;
        if (StageCount % 2 == 0) yBtnPos -= yBtnPosGap * 0.5f;

        //��ġ ����
        for (int i = 0; i < StageCount; i++)
        {
            UI_StageBtn btns = Instantiate(stageButtonPrefeb, parentsBtn.transform); //��ư ����
            btns.StageNum = DataManager.Instance.Stages[i].stageNum; //��ư�� value�� �߰� , value = �ش� Stage�� �ѹ���

            Vector2 btnPos = new Vector2(0, yBtnPos - (i * yBtnPosGap)); //��ư�� ���� ��ǥ
            btns.gameObject.GetComponent<RectTransform>().anchoredPosition = btnPos;//��ư ��ǥ ��ġ

            StageBtns.Add(btns);//������ ��ư ������Ʈ�� List�� �߰�
        }
        /* !Stage ������ ���� Stgae��ư ��ġ�� �ϱ� ���� ����! */

        //DataManager�� ��� Stage Data�� ȣ��
        List<Stage> stageList = DataManager.Instance.Stages;

        StageBtns[0].UnLock(); // 1���������� ������ ��� �Ǿ�����ϱ⶧���� 

        //Stage Data�� Ȯ���Ͽ� Stage �ر� ����
        for (int i =1; i < StageCount; i++) 
        {
            //���� Stage�� Ŭ���� �������� ���� Stage�� �رݽ�Ų��.
            if(stageList[i-1].isClear)
            {
                StageBtns[i].UnLock();
            }
        }

    }

}
