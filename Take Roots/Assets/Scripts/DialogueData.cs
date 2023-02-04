using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
    public string text;
    public string firstChoice;
    public string secondChoice;

}
