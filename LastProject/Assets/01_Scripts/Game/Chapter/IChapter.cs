using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChapter
{
    public void Init();
    public string GetLine(int lineIndex);
}
