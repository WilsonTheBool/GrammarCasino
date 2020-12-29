using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using Assets.Scripts.Voting;

[RequireComponent(typeof(PlayerMovementController), typeof(GameLoopController))]
public class GameController : MonoBehaviour
{
    public TaskWindowBehaviour TaskWindowBehaviour;
    public TableTimer TableTimer;
    public PlayerMovementController movementController;
    public PlayerInputController inputController;
    private TaskController taskController;
    private VoteController voteController;
    public ShowCanvasTransition transition;
    private GameLoopController loopController;

    public List<Player> allPlayers;
    private void Awake()
    {
        TaskWindowBehaviour = FindObjectOfType<TaskWindowBehaviour>();
        movementController = GetComponent<PlayerMovementController>();
        inputController = FindObjectOfType<PlayerInputController>();
        taskController = FindObjectOfType<TaskController>();
        holdersController = GetComponent<PlayerHoldersController>();
        voteController = GetComponent<VoteController>();
        transition = FindObjectOfType<ShowCanvasTransition>();
        loopController = GetComponent<GameLoopController>();


        TaskWindowBehaviour.CloseWindow();

        //allPlayers = new List<Player>( FindObjectsOfType<Player>(false));
        //allPlayers.Reverse();

        inputController.OnTrueFalseButtonPress += InputButtonPress;
        inputController.OnNumberButtonPress += InputButtonPress;
    }

    public PlayerHoldersController holdersController;

    private void Start()
    {
        holdersController.StartHolders(allPlayers.Count);
        movementController.DeleteInactiveViews();
        movementController.AddNewPlayer(allPlayers);
    }

    private void Update()
    {
    }

    private void CloseWindowOnTImerEnd()
    {
        TableTimer.timerEnded -= CloseWindowOnTImerEnd;

        TableTimer.StartTimer(5);

        TaskWindowBehaviour.CloseWindow();
    }

    /// <summary>
    /// Продвигает игроков, возвращает false если был сделан полный круг
    /// </summary>
    public bool PushNextPlayerVote()
    {
    start_push_label:

        movementController.PushPlayers();

        

        Player curent = inputController.GetCurentPlayer().Player;



        if (!curent.isPlayerActive)
        {
            goto start_push_label;
        }

        if (curent.isLeading)
        {
            //HideButtons();
            print("LEADER!!!!!!");
            return false;
        }
        else
        {
            //StartCoroutine(HideButtonsCo());
            return true;
        }
    }

    private int roundNumber = 1;

    public float betIncreaseMult;
    public void TickBetAmmount()
    {
        if(roundNumber % betIncRounds == 0)
        {
            minBet = Mathf.RoundToInt(betIncreaseMult * minBet);
        }

        roundNumber++;
    }

    public TaskBase curentTask;
    public void ShowTaskButtons(TaskBase task)
    {
        if (task is Task_TrueFalse)
        {
            inputController.ShowTrueFalseButtons();
        }
        else
        if (task is Task_Test)
        {
            inputController.ShowTestButtons();
        }
    }

    public void HideButtons()
    {
        inputController.HideButtons();
    }

    private IEnumerator HideButtonsCo()
    {
        inputController.HideButtons();
        TableTimer.gameObject.SetActive(false);
        inputController.GetCurentPlayer().gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        inputController.GetCurentPlayer().gameObject.SetActive(true);
        TableTimer.gameObject.SetActive(true);
        ShowTaskButtons(curentTask);

    }

    public float timeWaitAnswer;

    public float timeWaitAfterRound;

    public int minBet;

    public int betIncRounds;
    
    public void SetSettings(float timeAnwer, float timeAfterRound, int MinBet, int BetIncrementRounds)
    {
        timeWaitAnswer = timeAnwer;
        timeWaitAfterRound = timeAfterRound;
        minBet = MinBet;
        betIncRounds = BetIncrementRounds;

        loopController.SetUpGame(timeAnwer, timeAfterRound);
    }

    public TaskBase GetNewTask()
    {
        TaskWindowBehaviour.OpenWindow();

        TaskBase task = taskController.GetRandomTask(-1);

        TaskWindowBehaviour.SetQuestion(task.question);
        TaskWindowBehaviour.SetText(task.task);

        curentTask = task;
        return task;
    }

    public void HideTask()
    {
        if(TaskWindowBehaviour != null)
        TaskWindowBehaviour.CloseWindow();
    }

    private void InputButtonPress(bool vote)
    {
        TakeVote(inputController.GetCurentPlayer().Player, vote);

        OnButtonPress?.Invoke();
    }

    private void InputButtonPress(int vote)
    {
        TakeVote(inputController.GetCurentPlayer().Player, vote);

        OnButtonPress?.Invoke();
    }

    public Action OnButtonPress;

    private void TakeVote(Player p, bool vote)
    {
        BoolVote v = new BoolVote(p);
        v.SetVote(vote);

        voteController.TakeVote(v, curentTask);
    }

    private void TakeVote(Player p, int vote)
    {
        IntVote v = new IntVote(p);
        v.SetVote(vote);

        voteController.TakeVote(v, curentTask);
    }

    public float bank;

    public void TakeBets()
    {
        foreach (PlayerView playerView in movementController.playerViewsInOrder)
        {

                playerView.RemoveMoney(minBet);
                bank += minBet;


        }
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }

}
