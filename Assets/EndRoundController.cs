using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Voting;

public class EndRoundController : MonoBehaviour
{
    private ShowCanvasTransition transition;
    [SerializeField]
    private GameLoopController gameLoopController;

    [SerializeField]
    private VoteController voteController;

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private TableTimer timer;

    private TransferPlayers transferPlayers;

    [SerializeField]
    private TaskAnswerTextController answerWindow;

    [HideInInspector]
    public float endTimer;
    void Start()
    {
        transition = FindObjectOfType<ShowCanvasTransition>();
        transferPlayers = GetComponent<TransferPlayers>();
    }

    List<Player> players = new List<Player>();

    public void EndRound()
    {
        timer.StartTimer(endTimer);
        timer.timerEnded += ChangeToMain;

        SetUpWindow();

        ChangeMoney();

        ClearVotes();

        gameController.TickBetAmmount();

        players = new List<Player>();
        foreach (PlayerView view in transferPlayers.allViews)
        {
            

            if(view.Player != null && view.Player.isPlayerActive)
            players.Add(view.Player);
        }

        RemovePlayersInDebt();

        PushLeadingPlayer();

        foreach (PlayerView v in transferPlayers.allViews)
        {
            v.UpdateUI();
        }

    }

    void SetUpWindow()
    {

        answerWindow.SetNewText(gameController.curentTask);
    }
    void ChangeMoney()
    {
        int correctCount = 0;
        foreach (PlayerView view in transferPlayers.allViews)
        {
            if (view.isActiveAndEnabled)
            {
                VoteBase vote;
                if ((vote = voteController.GetVote(view.Player)) != null && vote.GetVoteResult()) 
                {
                    correctCount++;
                }
            }
        }

        foreach (PlayerView view in transferPlayers.allViews)
        {
            if (view.isActiveAndEnabled)
            {
                VoteBase vote;
                if ((vote = voteController.GetVote(view.Player)) != null && vote.GetVoteResult())
                {
                    
                    view.AddMoney(Mathf.RoundToInt(gameController.bank / correctCount));
                }
                else
                {
                    view.Player.money += gameController.minBet;
                    view.RemoveMoney(gameController.minBet);
                }
            }
        }

        if(correctCount > 0)
        {
            gameController.bank = 0;
        }
        
    }

    private void PushLeadingPlayer()
    {
        int leadId = 0;

        for(int i = 0; i < transferPlayers.allViews.Length; i++)
        {
            PlayerView view = transferPlayers.allViews[i];
            if (view.Player != null && view.Player.isLeading)
            {
                leadId = i;
            }
        }

        Player lastLead = players[leadId];

        players.RemoveAt(leadId);

        players.Insert(players.Count,  lastLead);

        bool isDone = false ;
        for(int i = leadId + 1; i < transferPlayers.allViews.Length; i++)
        {
            PlayerView view = transferPlayers.allViews[i];
            if (view.Player != null  && view.Player.isPlayerActive)
            {
                view.Player.isLeading = true;
                transferPlayers.allViews[leadId].Player.isLeading = false;
                isDone = true;
                break;
            }


        }

        if (!isDone)
        {
            for (int i = 0; i < leadId - 1; i++)
            {
                PlayerView view = transferPlayers.allViews[i];
                if (view.Player != null && view.Player.isPlayerActive)
                {
                    view.Player.isLeading = true;
                    transferPlayers.allViews[leadId].Player.isLeading = false;
                    isDone = true;
                    break;
                }


            }
        }
    }

    private void PushPlayersToMain(List<Player> players)
    {
        if(players.Count > 1)
        {
            transition.SwitchToGame();

            gameController.allPlayers.Clear();
            gameController.allPlayers.AddRange(players);

            SetHoldersCount(players.Count);

            gameController.movementController.AddNewPlayer(players);
        }
        else
        {
            if(players.Count == 1)
            {
                transition.SwitchToWictoryScreen(players[0]);
            }
            else
            {
                transition.SwitchToWictoryScreen(null);
            }
            
        }
   
    }

    void SetHoldersCount(int numOfPlayers)
    {

        gameController.holdersController.SetHoldersInactive(numOfPlayers);

        gameController.movementController.DeleteInactiveViews();
        
    }

    private void RemovePlayersInDebt()
    {
        //List<Player> del = new List<Player>();
        foreach(Player p in players)
        {
            if(p.money <= 0)
            {
                p.isPlayerActive = false;
               // del.Add(p);
            }

        }

        //foreach(Player p in del)
        //{
        //    players.Remove(p);
        //}
        
    }

    private void DeletePlayersInDebt()
    {
        List<Player> del = new List<Player>();
        foreach (Player p in players)
        {
            if (!p.isPlayerActive)
            {
                
                del.Add(p);
            }

        }

        List<PlayerView> views = new List<PlayerView>(transferPlayers.allViews);

        foreach (Player p in del)
        {

            views.RemoveAll((PlayerView view) => del.Contains(view.Player));

            players.Remove(p);
        }

        foreach(PlayerView view in transferPlayers.allViews)
        {
            if (del.Contains(view.Player))
            {
                Destroy(view.gameObject);
            }
        }

        transferPlayers.allViews = views.ToArray();

    }

    private void ClearVotes()
    {
        voteController.ResetVotes();
    }

    public void ChangeToMain()
    {
        DeletePlayersInDebt();

        PushPlayersToMain(players);


        timer.ResetTimer();
        
        gameLoopController.StartNextState();
    }

    void Update()
    {
        
    }
}
