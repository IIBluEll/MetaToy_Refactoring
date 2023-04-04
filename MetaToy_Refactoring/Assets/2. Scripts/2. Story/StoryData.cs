using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Story Data", menuName = "Scriptable Object/Story Data",order = int.MaxValue)]

public class StoryData : ScriptableObject
{
    [Header("[ Story Data ]")]
    [Multiline (5)]
    public string story;
    public float typingSpeed;
}
