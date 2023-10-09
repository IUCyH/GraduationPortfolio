using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton_DontDestroy<EventManager>
{
    Dictionary<Action, float> invokeFunc = new Dictionary<Action, float>();
    List<Action> funcList = new List<Action>();
    List<float> timerList = new List<float>();

    int order;

    protected override void OnStart()
    {
        StartCoroutine(Coroutine_Update());
    }

    IEnumerator Coroutine_Update()
    {
        while (true)
        {
            if (invokeFunc.Count > 0)
            {
                for (int i = 0; i < timerList.Count; i++)
                {
                    timerList[i] += Time.deltaTime;
                }

                int index = 0;
                foreach (var func in invokeFunc)
                {
                    if (func.Value <= timerList[index++])
                    {
                        func.Key();
                    }
                }
            }

            yield return null;
        }
    }

    public int AddFunc(Action func)
    {
        if (funcList.Contains(func)) return -1;
        
        funcList.Add(func);

        return order++;
    }

    public void Invoke(int orderNumber, float time)
    {
        var func = funcList[orderNumber];

        if (invokeFunc.ContainsKey(func)) return;
        
        invokeFunc.Add(func, time);
        timerList.Add(0f);
    }

    public void CancelInvoke(int orderNumber, float time)
    {
        var func = funcList[orderNumber];

        invokeFunc.Remove(func);
        timerList.Remove(time);
    }

    public void CancelAllInvoke()
    {
        invokeFunc.Clear();
        timerList.Clear();
    }
}
