using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("House"))
        {
            collision.GetComponentInParent<House>().SetActiveInteractButton(true);
            Debug.Log("House touched");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("House"))
        {
            collision.GetComponentInParent<House>().SetActiveInteractButton(false);
            Debug.Log("House exit");
        }
    }
}
