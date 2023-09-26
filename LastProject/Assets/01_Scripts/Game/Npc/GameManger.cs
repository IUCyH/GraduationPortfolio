using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMoveMent;

    TalkObjects ScanObject;

    [SerializeField]
    TalkManager talkManager;
    [SerializeField]
    TextMeshProUGUI talkText;

    [SerializeField]
    GameObject talkPanel;
    [SerializeField]
    Image potraitImg;

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
        string talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;//강제 종료(함수 실행 안함)
        }

        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];

            potraitImg.sprite = talkManager.GetPotrait(id, int.Parse(talkData.Split(':')[1]));
            potraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;

            potraitImg.color = new Color(1, 1, 1, 0);
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