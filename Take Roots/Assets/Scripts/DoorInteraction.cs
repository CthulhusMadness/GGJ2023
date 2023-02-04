using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private House house;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            house.SetActiveInteractButton(true);
            collision.GetComponentInParent<Player>().canInteract = true;
            Debug.Log("House touched");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            house.SetActiveInteractButton(false);
            collision.GetComponentInParent<Player>().canInteract = false;
            Debug.Log("House exit");
        }
    }
}
