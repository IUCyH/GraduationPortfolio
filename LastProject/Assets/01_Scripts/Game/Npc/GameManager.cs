using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMoveMent;

    TalkObjects scanObject;

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

    public void Action()
    {
        Talk(scanObject.npcID, scanObject.isNpc);

        talkPanel.SetBool("isShow", isAction    );
        playerMoveMent.enabled = !isAction;
    }

    public void CallScanObject(TalkObjects talkObjects)
    {
        scanObject = talkObjects;
    }
}