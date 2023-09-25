using TMPro;
using UnityEngine;

public class TalkManger : MonoBehaviour
{
    [SerializeField]
    TalkInformationManager talkinformaitionManager;
    [SerializeField]
    TextMeshProUGUI talkText;

    TalkObjects ScanObject;

    [SerializeField]
    GameObject talkPanel;

    [SerializeField]
    int talkIndex;

    [SerializeField]
    bool isAction;    

    public void Action()
    {       
        Talk(ScanObject.npcID, ScanObject.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkinformaitionManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;//강제 종료(함수 실행 안함)
        }

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScanObject = collision.GetComponent<TalkObjects>();
    }
}
