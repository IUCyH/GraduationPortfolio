using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton_DontDestroy<GameManager>
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
    Sprite prevPotrait;

    [SerializeField]
    List<Sprite> allPlayerSprites;
    [SerializeField]
    Sprite playerSprite;

    [SerializeField]
    int talkIndex;

    [SerializeField]
    int playerNumber;

    [SerializeField]
    bool isAction;

    public int PlayerID => playerNumber;

    protected override void OnAwake()
    {
        //Player 관련 초기설정 전부 SetPlayer 함수로 이동시키기
        //플레이어 정보 가져와서 스프라이트 변경
        playerSprite = allPlayerSprites[playerNumber];
        //TODO : 플레이어의 id에 맞는 애니메이션 컨트롤러로 변경(Animation/AnimationController/Player에 저장돼 있음, 차레대로 신영, 지은, 재환, 신영을 제외한 나머지 컨트롤러는 animator override controller)
    }

    public void SetPlayer(int playerID)
    {
        playerNumber = playerID;
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