using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{
    [SerializeField]
    Text moneyStart;

    [SerializeField]
    Text moneyStartBet;

    [SerializeField]
    Text moneyIncrementBet;

    [SerializeField]
    Text roundTime;

    [SerializeField]
    Text reoundEndTime;

    [SerializeField]
    Toggle truefalseTasks;

    [SerializeField]
    Toggle testTasks;

    public GameController gameController;
    public TransferPlayers transfer;

    [SerializeField]
    private GameObject playerHolder;

    [SerializeField]
    private ShowCanvasTransition canvasTransition;

    [SerializeField]
    private GroupTaskController GroupTaskController;

    [SerializeField]
    private TypeTaskControlelr TypeTaskController;

    [SerializeField]
    private TaskController TaskController;

    public void StartGame()
    {
        AddPlayers();

        LoadTasks();

        canvasTransition.SwitchToGame();
        gameController.gameObject.SetActive(true);
        transfer.gameObject.SetActive(true);

        SetSetings();

        
    }

    public void SetSetings()
    {
        gameController.SetSettings(float.Parse(roundTime.text), float.Parse(reoundEndTime.text),
            int.Parse(moneyStartBet.text), int.Parse(moneyIncrementBet.text));


    }

    public GameObject playerPrefab;

    [SerializeField]
    PlayerCreateHolder[] players;
    private void AddPlayers()
    {
        players = GetComponentsInChildren<PlayerCreateHolder>();
        List<Player> all_players_in_order  = new List<Player>();
        
        foreach(var view in players)
        {
            var temp = Instantiate<GameObject>(playerPrefab, playerHolder.transform);

            Player p = temp.GetComponent<Player>();



            view.GetPlayer(ref p);

            p.money = int.Parse(moneyStart.text);

            all_players_in_order.Add(p);
        }

        gameController.allPlayers = all_players_in_order;

    }

    private void LoadTasks()
    {
        TaskController.LoadTasks(GroupTaskController.GetActivatedGroups(), TypeTaskController.GetActivatedGroups());
    }
}
