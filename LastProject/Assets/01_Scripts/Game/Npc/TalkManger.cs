using System.ComponentModel;
using TMPro;
using UnityEngine;

public class TalkManger : MonoBehaviour
{
    [SerializeField]
    TalkInformation talkinformaition;
    [SerializeField]
    TextMeshProUGUI talkText;

    [SerializeField] //�׽�Ʈ ReadOnly ���� ��?
    TalkObjects ScanObject; 

    [SerializeField]
    PlayerMovement playerMoveMent;

    [SerializeField]
    GameObject talkPanel;

    [SerializeField]
    int talkIndex;

    [SerializeField]
    bool isAction;
    bool isCollisiontNPC;

    void Start()
    {
        talkPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollisiontNPC)
        {
            Action();
        }
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkinformaition.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;//���� ����(�Լ� ���� ����)
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

    void Action()
    {
        Talk(ScanObject.npcID, ScanObject.isNpc);

        talkPanel.SetActive(isAction);      
        playerMoveMent.enabled = !isAction;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScanObject = collision.GetComponent<TalkObjects>();

        if (collision.gameObject.CompareTag("NPC"))
        {
            isCollisiontNPC = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            isCollisiontNPC = false;
        }
    }
}