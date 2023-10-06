using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
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

    float interval;

    public bool isAnim;

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();            
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }      
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f / charPerSeconds;

        isAnim = true;

        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();    
            return;
        }

        msgText.text += targetMsg[index];


        if (targetMsg[index] != ' ' && targetMsg[index] != '.')
            SoundManager.Instance.PlaySFX(SFX.Talk);
        
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;

        EndCursor.SetActive(true);
    }
}
