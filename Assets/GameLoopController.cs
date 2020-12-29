using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLoopController : MonoBehaviour
{
    private GameController gameController;
    private TransferPlayers transfer;
    [SerializeField]
    private EndRoundController endRound;

    private void Start()
    {
        gameController = GetComponent<GameController>();
        transfer = FindObjectOfType<TransferPlayers>();

        gameController.OnButtonPress += OnInputButtonPress;

        StartCoroutine(Corutine_delay_1(1));
        
    }
    public enum GameState
    {
        None,
        TakeNewBets,
        TaskPresented,
        PlayersTakingVotes,
        TaskAnswerPresented,
        PlayersGainLooseMoney,
        RemovePlayers,
    }

    public GameState gameState;

    public void OnTaskPresented()
    {
        gameController.TaskWindowBehaviour.CloseWindow();
        gameController.TableTimer.ResetTimer();


        StartCoroutine(NewRoundDelayCo());
    }

    [SerializeField]
    private GameObject newTaskAyeCatcher;

    [SerializeField]
    private GameObject endRoundAyeCatcher;
    private IEnumerator Corutine_delay_1(int sec)
    {
        yield return new WaitForSeconds(sec);

        OnTakeBetStart();

    }

    public void SetUpGame(float answerTime, float endRoundTime)
    {
        this.answerTime = answerTime;
        endRound.endTimer = endRoundTime;
    }
    private IEnumerator NewRoundDelayCo()
    {
        yield return new WaitForSeconds(1);

        newTaskAyeCatcher.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        newTaskAyeCatcher.gameObject.SetActive(false);

        //показать задание
        TaskBase task = gameController.GetNewTask();

        //показать кнопки
        gameController.ShowTaskButtons(task);

        //запустить таймер задания (после окончания: push player, перевести gameState в Игроки голосуют)

        //gameController.TableTimer.StartTimer(20);
        //gameController.TableTimer.timerEnded += TimerDelegate_TaskPresented;
        //gameState = GameState.PlayersTakingVotes;

        StartNextState();
    }

    private IEnumerator StartRoundDelayCo()
    {

        endRoundAyeCatcher.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        endRoundAyeCatcher.gameObject.SetActive(false);

    }

    public float answerTime = 10;

    public void StartNextState()
    {
        switch (gameState)
        {
            case GameState.TakeNewBets:
                {
                    OnTaskPresented();
                    gameState = GameState.TaskPresented;

                    return;
                }
            case GameState.TaskPresented:
                {
                    gameState = GameState.PlayersTakingVotes;
                    gameController.TableTimer.StartTimer(answerTime);
                    gameController.TableTimer.timerEnded += TimerDelegate_PlayerVote;

                    

                    return;
                }
            case GameState.PlayersTakingVotes:
                {
                    gameState = GameState.TaskAnswerPresented;
                    gameController.TableTimer.ResetTimer();

                    gameController.HideButtons();
                    gameController.HideTask();
                    ///////////////////////////////////////
                    RoundEnd();

                    return;
                }
            case GameState.TaskAnswerPresented:
                {
                    OnTakeBetStart();
                    return;
                }
        }
        
    }

    private void RoundEnd()
    {
        gameState = GameState.TaskAnswerPresented;
        gameController.transition.SwitchToEndRound();
        transfer.Transfer();
        endRound.EndRound();

    }

    private void  OnTakeBetStart()
    {
        StartCoroutine(StartRoundDelayCo());
        gameController.TakeBets();
        gameState = GameState.TakeNewBets;
        gameController.TableTimer.ResetTimer();
        gameController.TableTimer.StartTimer(2);
        gameController.TableTimer.timerEnded += TimerDelegate_TakeBets;
    }

    private void TimerDelegate_TakeBets()
    {
        StartNextState();
    }

    private void TimerDelegate_PlayerVote()
    {
        if (!gameController.PushNextPlayerVote())
        {
            gameController.TableTimer.ResetTimer();
            StartNextState();
            
        }
        else
        {
            gameController.TableTimer.StartTimer(answerTime);
        }
    }

    private void TimerDelegate_TaskPresented()
    {
        gameController.PushNextPlayerVote();
        gameController.TableTimer.ResetTimer();
        StartNextState();
    }

    public void OnInputButtonPress()
    {
        //PushPlayers
        TimerDelegate_PlayerVote();
    }
}
