using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    public Player player;
    public House currentHouse;

    private void Start()
    {
        player.inputHandler.OnInteract += OnInteract;
        player.inputHandler.OnEndInteract += OnEndInteract;
    }

    private void OnDestroy()
    {
        player.inputHandler.OnInteract -= OnInteract;
        player.inputHandler.OnEndInteract -= OnEndInteract;
    }

    public void SetCurrentHouse(House house)
    {
        currentHouse = house;
    }

    private bool OnInteract()
    {
        if (currentHouse != null)
        {
            currentHouse.StartInteraction(player);
            return true;
        }
        return false;
    }

    private void OnEndInteract()
    {
        if (currentHouse != null)
        {
            currentHouse.EndInteraction();
        }
    }
}
