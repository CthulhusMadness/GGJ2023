using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InteractionManager;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogue;
    [SerializeField] private ChoiseButton firstChoise;
    [SerializeField] private ChoiseButton secondChoise;
    [SerializeField] private ChoiseButton thirdChoise;

    [SerializeField] private List<ChoiseButton> choiseButtons = new List<ChoiseButton>();

    public bool isDialogeReady;
    public int currentChoiseIndex;

    public void Initialize(DialogueData dialogueData)
    {
        isDialogeReady = false;
        dialogue.text = string.Empty;
        firstChoise.SetText(dialogueData.FirstChoise.Text);
        firstChoise.SetActivePointer(false);
        firstChoise.gameObject.SetActive(false);
        secondChoise.SetText(dialogueData.SecondChoise.Text);
        secondChoise.SetActivePointer(false);
        secondChoise.gameObject.SetActive(false);
        thirdChoise.SetText(dialogueData.ThirdChoise.Text);
        thirdChoise.SetActivePointer(false);
        thirdChoise.gameObject.SetActive(false);

        StartCoroutine(TypeDialogue(dialogueData.Text, dialogueData.typingSpeed));
    }

    private IEnumerator TypeDialogue(string dialogueText, float typingSpeed)
    {
        var charIndex = 0;
        while (!dialogue.text.Equals(dialogueText))
        {
            var _char = dialogueText[charIndex];
            dialogue.text += _char;
            charIndex++;
            yield return new WaitForSeconds(typingSpeed);
        }
        OnEndTyping();
    }

    private void OnEndTyping()
    {
        firstChoise.gameObject.SetActive(true);
        secondChoise.gameObject.SetActive(true);
        thirdChoise.gameObject.SetActive(true);
        SetCurrentChoise(0);
        isDialogeReady = true;
    }

    public int GetSelectedChoiseIndex() => currentChoiseIndex;

    private void SetCurrentChoise(int choiseIndex, int prevChoiseIndex = -1)
    {
        if (prevChoiseIndex >= 0)
            choiseButtons[prevChoiseIndex].SetActivePointer(false);
        choiseButtons[choiseIndex].SetActivePointer(true);
        currentChoiseIndex = choiseIndex;
    }

    public void ChangeChoiseButton(EDirection direction)
    {
        int prevChoiseIndex = currentChoiseIndex;
        switch (direction)
        {
            case EDirection.Up:
                currentChoiseIndex--;
                if (currentChoiseIndex < 0)
                    currentChoiseIndex = choiseButtons.Count - 1;
                break;
            case EDirection.Down:
                currentChoiseIndex++;
                if (currentChoiseIndex >= choiseButtons.Count)
                    currentChoiseIndex = 0;
                break;
        }
        SetCurrentChoise(currentChoiseIndex, prevChoiseIndex);
    }
}
