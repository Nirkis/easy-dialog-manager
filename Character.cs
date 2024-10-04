using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Dilog System/Character")]
public class Character : ScriptableObject
{
    public string name_cherecter = "";
    public AudioClip soundPrint;
    public Sprite avatar_image;
    public Sprite avatar_image_2;
}