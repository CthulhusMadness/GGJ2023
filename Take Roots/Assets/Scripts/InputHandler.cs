using System;
using UnityEngine;

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

    private void OnInput()
    {
        movementDir = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * movementDir * speed, Space.World);
    }
}