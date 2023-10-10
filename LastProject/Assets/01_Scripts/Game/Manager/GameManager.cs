using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    Image potraitImg;
    [SerializeField]
    List<Sprite> allPlayePotrait;

    [SerializeField]
    TalkManager talkManager;
    
    [SerializeField]
    Animator potraitAnim;  

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
        
        //TODO : 플레이어의 id에 맞는 애니메이션 컨트롤러로 변경(Animation/AnimationController/Player에 저장돼 있음, 차레대로 신영, 지은, 재환, 신영을 제외한 나머지 컨트롤러는 animator override controller)
    }

    public void SetPlayer(int playerID)
    {
        playerNumber = playerID;
        //playerSprite = allPlayePotrait[playerNumber];
    }

    public void SetPotrait(int id)
    {
        potraitImg.sprite = allPlayePotrait[id];
    }
}