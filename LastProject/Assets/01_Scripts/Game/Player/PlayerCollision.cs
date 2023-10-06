using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    bool isCollisiontNPC;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollisiontNPC)
        {
            TalkManager.Instance.Action();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        TalkManager.Instance.CallScanObject(collision.GetComponent<TalkObjects>());     

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
