using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    bool isCollisiontNPC;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollisiontNPC)
        {
            gameManager.Action();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.CallScanObject(collision.GetComponent<TalkObjects>());     

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
