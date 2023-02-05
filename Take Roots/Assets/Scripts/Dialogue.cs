using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [SerializeField] private DialogueData data;
    [SerializeField] private bool used;


    public bool getUsed()
    {
        return used;
    }

    public void setUsed(bool u)
    {
        used = u;
    }

    public DialogueData getData()
    {
        return data;
    }
}
