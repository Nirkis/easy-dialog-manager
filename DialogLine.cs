using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dilog Line", menuName = "Dilog System/Dilog Line")]
public class DialogLine : ScriptableObject
{
     public List<DilogString> LineOfDilog = new List<DilogString>();
}
[System.Serializable]
public class DilogString
{
    public bool isAutoSkip;
    [TextArea] public string text;
    public Character cher;
}
