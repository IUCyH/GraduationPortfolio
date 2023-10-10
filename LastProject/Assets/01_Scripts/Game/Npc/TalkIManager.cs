using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : Singleton<TalkManager>
{
    TalkObjects scanObject;

    [SerializeField]
    TypeEffect typeEffect;
    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    Animator talkPanel;  

    int talkIndex;

    bool isAction;
   
    void Talk(bool isNpc)
    {
        //int questTalkIndex = 0;
        string talkData = "";


        if (typeEffect.isAnim)
        {
            typeEffect.SetMsg("");
            return;
        }
        else
        {
            //questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = GameStoryManager.Instance.GetDialogue(talkIndex);
        }



        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;//강제 종료(함수 실행 안함)
        }

        int id = 0;

        if (isNpc)
        {          
            if (talkData.StartsWith("지은_"))
            {
                id = 0;
            }
            else if (talkData.StartsWith("신영_"))
            {
                id = 1;
            }
            else if (talkData.StartsWith("재환_"))
            {
                id = 2;
            }

            GameManager.Instance.SetPotrait(id);
            var result = talkData.Split('_');
            Debug.Log(talkData);
            typeEffect.SetMsg(result.Length > 1 ? result[1] : result[0]);
            
        }

        isAction = true;
        talkIndex++;
    }

    public void Action()
    {
        Debug.Log("Action");
        Talk(scanObject.isNpc);

        talkPanel.SetBool("isShow", isAction);
        playerMovement.enabled = !isAction;
    }

    public void CallScanObject(TalkObjects talkObjects)
    {
        scanObject = talkObjects;
    }
}
