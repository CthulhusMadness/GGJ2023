using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
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
