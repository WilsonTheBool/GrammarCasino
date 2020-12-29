using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldersController : MonoBehaviour
{
    public List<GameObject> allPlayerHoldersInOrder;


    public void SetHoldersInactive(int numOfPlayers)
    {
        Debug.Log("Set holders inactive: " + numOfPlayers.ToString() + " ->" + allPlayerHoldersInOrder.Count);
        for(int i = allPlayerHoldersInOrder.Count - 1; i > numOfPlayers - 2; i--)
        {
            allPlayerHoldersInOrder[i].SetActive(false);
        }
    }


    public void StartHolders(int numPlayers)
    {
        SetHoldersInactive(numPlayers);
    }
}
