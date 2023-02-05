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

    private const int MaxInteractionsPerDay = 3;
    public int interactionsCount = 0;

    private void Start()
    {
        OnStartDay();
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

    public void OnStartDay()
    {
        interactionsCount = 0;
    }

    public void SetCurrentHouse(House house)
    {
        currentHouse = house;
    }

    private bool OnInteract()
    {
        if (interactionsCount < MaxInteractionsPerDay)
        {
            if (currentHouse != null && currentHouse.GetAvailableDialogue() != null)
            {
                currentHouse.StartInteraction(player);
                cameraManager.SetTarget(currentHouse.cameraPoint);
                cameraManager.Zoom(true);
                return true;
            }
        }
        return false;
    }

    private void OnEndInteract(bool isInteractionCompleted)
    {
        if (currentHouse != null)
        {
            cameraManager.SetTarget(player.cameraTarget);
            cameraManager.Zoom(false);
            if (isInteractionCompleted)
                interactionsCount++;
            if (interactionsCount >= MaxInteractionsPerDay)
                SceneManager.Instance.ChangeScene();
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
            UpdateScores(choise);
            player.inputHandler.ChangeInputType(InputHandler.EInputType.Movement);
            OnEndInteract(choise.IsAnswer);
        }
    }

    public void UpdateScores(DialogueChoice choise)
    {
        GameManager.Instance.setBirdScore(choise.BirdScore);
        GameManager.Instance.setCowScore(choise.CowScore);
        GameManager.Instance.setDogScore(choise.DogScore);
    }
}