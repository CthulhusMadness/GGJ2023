using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
    public float typingSpeed = .1f;
    [Multiline(10)]
    [SerializeField] private string text;
    [SerializeField] private DialogueChoice firstChoice;
    [SerializeField] private DialogueChoice secondChoice;

    public string getText()
    {
        return text;
    }

    public string getFirstChoice()
    {
        return firstChoice;
    }

    public string getSecondChoice()
    {
        return secondChoice;
    }
}
