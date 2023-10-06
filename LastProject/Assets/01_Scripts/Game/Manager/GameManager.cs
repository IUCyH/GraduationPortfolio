using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{    

    [SerializeField]
    TalkManager talkManager;
    
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
        //Player ���� �ʱ⼳�� ���� SetPlayer �Լ��� �̵���Ű��
        //�÷��̾� ���� �����ͼ� ��������Ʈ ����
        
        //TODO : �÷��̾��� id�� �´� �ִϸ��̼� ��Ʈ�ѷ��� ����(Animation/AnimationController/Player�� ����� ����, ������� �ſ�, ����, ��ȯ, �ſ��� ������ ������ ��Ʈ�ѷ��� animator override controller)
    }

    public void SetPlayer(int playerID)
    {
        playerNumber = playerID;
        //playerSprite = allPlayerSprites[playerNumber];
    }

    
}