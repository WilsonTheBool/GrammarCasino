using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPlayers : MonoBehaviour
{
    [SerializeField]
    public PlayerView[] allViews;

    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Transfer()
    {
        for (int i = 0; i < gameController.allPlayers.Count; i++)
        {
            allViews[i].SetPlayer(gameController.allPlayers[i]);
            allViews[i].UpdateUI();
        }

        foreach(PlayerView view in allViews)
        {
            if(view.Player == null)
            {
                view.gameObject.SetActive(false);
            }
        }
    }
}
