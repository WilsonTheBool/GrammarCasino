using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    public List<PlayerView> playerViewsInOrder;

    public void DeleteInactiveViews()
    {
        for(int i = 0; i < playerViewsInOrder.Count; i++)
        {
            if (!playerViewsInOrder[i].isActiveAndEnabled)
            {
                playerViewsInOrder.RemoveAt(i);
                Debug.Log("Удален VIEW = " + i);
                i--;
            }
        }
    }

    private void Start()
    {
        //DeleteInactiveViews();

    }

    public void AddNewPlayer(List<Player> players)
    {
        if(players.Count != playerViewsInOrder.Count)
        {
            Debug.Log("При создании игры кол-во игроков не совпадало с кол-вом мест");
            Debug.Log("PLayer:" + players.Count.ToString() + " Views: " + playerViewsInOrder.Count.ToString());
        }
        
        for(int i = 0; i < playerViewsInOrder.Count; i++)
        {
            playerViewsInOrder[i].SetPlayer(players[i]);
        }
    }

    public void PushPlayers()
    {
        

        Player curent = playerViewsInOrder[0].Player;
        for( int i = playerViewsInOrder.Count - 1; i >= 0; i--)
        {
            var view = playerViewsInOrder[i];
            Player player = view.Player;
            view.SetPlayer(curent);
            curent = player;
        }
    }

    private IEnumerator SwitchPlayersCor()
    {
        return null;
    }

}
