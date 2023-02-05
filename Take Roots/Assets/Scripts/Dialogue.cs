using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
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
