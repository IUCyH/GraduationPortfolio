using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeManager : Singleton_DontDestroy<InvokeManager>
{
    Dictionary<Action, float> invokeFunc = new Dictionary<Action, float>();
    List<Action> repeatingFuncList = new List<Action>();
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
                for (int i = 0; i < funcList.Count; i++)
                {
                    var func = funcList[i];

                    if (invokeFunc.TryGetValue(func, out float time))
                    {
                        var timer = timerList[index];

                        if (time <= timer)
                        {
                            if (!repeatingFuncList.Contains(func))
                            {
                                CancelInvoke(func, timer);
                            }
                            else
                            {
                                timerList[index++] = 0f;
                            }

                            func();
                        }
                    }
                }
            }

            yield return null;
        }
    }

    public int AddFunc(Action func)
    {
        if (funcList.Contains(func)) return funcList.IndexOf(func);
        
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

    public void InvokeRepeating(int orderNumber, float time)
    {
        var func = funcList[orderNumber];

        if (invokeFunc.ContainsKey(func)) return;

        invokeFunc.Add(func, time);
        timerList.Add(0f);
        
        repeatingFuncList.Add(func);
    }

    public void CancelInvoke(Action func, float time)
    {
        invokeFunc.Remove(func);
        timerList.Remove(time);
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
