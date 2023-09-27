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
    TypeEffect talk;

    [SerializeField]
    Animator talkPanel;
    [SerializeField]
    Animator potraitAnim;
    [SerializeField]
    Image potraitImg;

    [SerializeField]
    int talkIndex;
    [SerializeField]
    Sprite prevPotrait;

    [SerializeField]
    bool isAction;
    bool isCollisiontNPC;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollisiontNPC)
        {
            Action();
        }
    }

    void Talk(int id, bool isNpc)
    {
        //int questTalkIndex = 0;
        string talkData = "";


        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            //questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id, talkIndex);
        }

       

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;//강제 종료(함수 실행 안함)
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            potraitImg.sprite = talkManager.GetPotrait(id, int.Parse(talkData.Split(':')[1]));
            potraitImg.color = new Color(1, 1, 1, 1);

            if (prevPotrait != potraitImg.sprite)
            {
                potraitAnim.SetTrigger("doEffect");
                prevPotrait = potraitImg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkData);

            potraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    void Action()
    {
        Talk(ScanObject.npcID, ScanObject.isNpc);

        talkPanel.SetBool("isShow", isAction    );
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