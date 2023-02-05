using System;
using UnityEngine;
using static InteractionManager;

public class InputHandler : MonoBehaviour
{
    public enum EInputType
    {
        Movement,
        Interaction
    }

    public EInputType InputType;

    [SerializeField] private float speed = 10f;
    private int movementDir = 0;

    public event Func<bool> OnInteract;
    public event Action<EDirection> OnChangeChoise;
    public event Action OnSelectChoise;

    private void Start()
    {
        InputType = EInputType.Movement;
    }

    private void Update()
    {
        OnInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void ChangeInputType(EInputType inputType) => InputType = inputType;

    private void OnInput()
    {
        movementDir = 0;
        if (InputType == EInputType.Movement)
        {
            movementDir = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var hasInteracted = OnInteract?.Invoke();
                if (hasInteracted == true)
                    ChangeInputType(EInputType.Interaction);
            }
        }
        else if (InputType == EInputType.Interaction)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                OnChangeChoise?.Invoke(EDirection.Up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                OnChangeChoise?.Invoke(EDirection.Down);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSelectChoise?.Invoke();
            }
        }
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * movementDir * speed, Space.World);
    }
}