using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    public enum EDirection
    {
        Up,
        Down
    }

    public Player player;
    public House currentHouse;
    public CameraManager cameraManager;

    private void Start()
    {
        player.inputHandler.OnInteract += OnInteract;
        player.inputHandler.OnChangeChoise += ChangeChoise;
        player.inputHandler.OnSelectChoise += SelectChoise;
    }

    private void OnDestroy()
    {
        player.inputHandler.OnInteract -= OnInteract;
        player.inputHandler.OnChangeChoise -= ChangeChoise;
        player.inputHandler.OnSelectChoise -= SelectChoise;
    }

    public void SetCurrentHouse(House house)
    {
        if (currentHouse != null)
            currentHouse.OnEndInteraction -= OnEndInteract;
        currentHouse = house;
        if (currentHouse != null)
            currentHouse.OnEndInteraction += OnEndInteract;
    }

    private bool OnInteract()
    {
        if (currentHouse != null && currentHouse.GetAvailableDialogue() != null)
        {
            currentHouse.StartInteraction(player);
            cameraManager.SetTarget(currentHouse.cameraPoint);
            cameraManager.Zoom(true);
            return true;
        }
        return false;
    }

    private void OnEndInteract()
    {
        if (currentHouse != null)
        {
            cameraManager.SetTarget(player.cameraTarget);
            cameraManager.Zoom(false);
        }
    }

    public void ChangeChoise(EDirection direction)
    {
        if (currentHouse.dialogueHandler.isDialogeReady)
            currentHouse.dialogueHandler.ChangeChoiseButton(direction);
    }

    public void SelectChoise()
    {
        if (currentHouse.dialogueHandler.isDialogeReady)
        {
            var choiseIndex = currentHouse.dialogueHandler.GetSelectedChoiseIndex();
            DialogueChoice choise = null;
            if (choiseIndex == 0)
                choise = currentHouse.CurrentDialogue.getData().FirstChoise;
            else if (choiseIndex == 1)
                choise = currentHouse.CurrentDialogue.getData().SecondChoise;
            else if (choiseIndex == 2)
                choise = currentHouse.CurrentDialogue.getData().ThirdChoise;

            currentHouse.EndInteraction(choise.IsAnswer);
            player.inputHandler.ChangeInputType(InputHandler.EInputType.Movement);
        }
    }
}
