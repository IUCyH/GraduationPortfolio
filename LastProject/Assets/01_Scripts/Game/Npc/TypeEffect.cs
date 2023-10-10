using System;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    [SerializeField]
    TextMeshProUGUI msgText;
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameObject EndCursor;

    string targetMsg;

    [SerializeField]
    int charPerSeconds;
       
    int index;
    int orderOfEffecting;

    float interval;

    public bool isAnim;

    void Awake()
    {
        orderOfEffecting = InvokeManager.Instance.AddFunc(() => Effecting());
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;

            EffectEnd();
            InvokeManager.Instance.CancelAllInvoke();         
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = string.Empty;
        index = 0;
        sb.Clear();
        EndCursor.SetActive(false);

        interval = 1.0f / charPerSeconds;

        isAnim = true;

        InvokeManager.Instance.Invoke(orderOfEffecting, interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        sb.Append(targetMsg[index]);
        Debug.Log(sb.ToString());
        msgText.text = sb.ToString();

        if (targetMsg[index] != ' ' && targetMsg[index] != '.')
            SoundManager.Instance.PlaySFX(SFX.Talk);
        
        index++;

        InvokeManager.Instance.Invoke(orderOfEffecting, interval);
    }

    void EffectEnd()
    {
        isAnim = false;

        EndCursor.SetActive(true);
    }
}
