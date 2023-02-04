using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Neighbor neighbor;
    [SerializeField] private Transform playerPoint;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private List<Dialogue> houseDialoguesList = new List<Dialogue>();

    public event Action OnStartInteraction;
    public event Action OnEndInteraction;

    private void Start()
    {
        SetActiveInteractButton(false);
        neighbor.SetActive(false);
    }

    public void SetActiveInteractButton(bool active) => interactButton.SetActive(active);

    public void interact()
    {
        Debug.Log("funziono");
    }
}
