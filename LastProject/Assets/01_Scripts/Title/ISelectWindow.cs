using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectWindow
{
    int Level { get; }
    
    void Open();
    void Close();
}
