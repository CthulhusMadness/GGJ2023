using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
    public float typingSpeed = .1f;
    [Multiline(10)]
    [SerializeField] private string text;
    public string Text => text;
    [SerializeField] private DialogueChoice firstChoice;
    public DialogueChoice FirstChoise => firstChoice;
    [SerializeField] private DialogueChoice secondChoice;
    public DialogueChoice SecondChoise => secondChoice;
    [SerializeField] private DialogueChoice thirdChoice;
    public DialogueChoice ThirdChoise => thirdChoice;
}
