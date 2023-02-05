using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public bool IsInteracting = false;

    public Neighbor neighbor;
    public DialogueHandler dialogueHandler;
    public Transform cameraPoint;
    [SerializeField] private Transform playerPoint;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private List<Dialogue> houseDialogues = new List<Dialogue>();

    private Dialogue currentDialogue = null;
    public Dialogue CurrentDialogue => currentDialogue;

    public event Action OnStartInteraction;
    public event Action OnEndInteraction;

    private void Start()
    {
        SetActiveInteractButton(false);
        neighbor.gameObject.SetActive(false);
        IsInteracting = false;
        currentDialogue = null;
    }

    public void SetActiveInteractButton(bool active)
    {
        if (GetAvailableDialogue() != null)
            interactButton.SetActive(active);
    }

    public void StartInteraction(Player player)
    {
        currentDialogue = GetAvailableDialogue();
        if (currentDialogue != null)
        {
            neighbor.gameObject.SetActive(true);
            dialogueHandler.Initialize(currentDialogue.getData());
            player.transform.position = playerPoint.position;
            OnStartInteraction?.Invoke();
        }
    }

    public void EndInteraction(bool setDialogeUsed)
    {
        neighbor.gameObject.SetActive(false);
        currentDialogue.setUsed(setDialogeUsed);
        OnEndInteraction?.Invoke();
        if (GetAvailableDialogue() == null)
        {
            // Disable interaction with door
        }
    }

    public Dialogue GetAvailableDialogue()
    {
        return houseDialogues.Find(d => !d.getUsed());
    }
}
