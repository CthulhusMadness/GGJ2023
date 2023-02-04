using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;

    private void Start()
    {
        SetActiveInteractButton(false);
    }

    public void SetActiveInteractButton(bool active) => interactButton.SetActive(active);
}
