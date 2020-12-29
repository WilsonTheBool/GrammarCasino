using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasTransition : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas;

    [SerializeField]
    private Canvas createPlayerCanvas;

    [SerializeField]
    private Canvas ShowResultsCanvas;


    [SerializeField]
    private Canvas WictoryScreenCanvas;

    [SerializeField]
    PlayerView winerPlayerView;

    private void Start()
    {
        mainCanvas.gameObject.SetActive(false);
        createPlayerCanvas.gameObject.SetActive(true);
        ShowResultsCanvas.gameObject.SetActive(false);
        WictoryScreenCanvas.gameObject.SetActive(false);
    }

    public void SwitchToGame()
    {
        mainCanvas.gameObject.SetActive(true);
        createPlayerCanvas.gameObject.SetActive(false);
        ShowResultsCanvas.gameObject.SetActive(false);
        WictoryScreenCanvas.gameObject.SetActive(false);
    }

    public void SwitchToEndRound()
    {
        mainCanvas.gameObject.SetActive(false);
        createPlayerCanvas.gameObject.SetActive(false);
        WictoryScreenCanvas.gameObject.SetActive(false);
        ShowResultsCanvas.gameObject.SetActive(true);
    }
    
    public void SwitchToStartMenu()
    {
        mainCanvas.gameObject.SetActive(false);
        createPlayerCanvas.gameObject.SetActive(true);
        ShowResultsCanvas.gameObject.SetActive(false);
        WictoryScreenCanvas.gameObject.SetActive(false);
    }

    public void SwitchToWictoryScreen(Player winer)
    {
        mainCanvas.gameObject.SetActive(false);
        createPlayerCanvas.gameObject.SetActive(false);
        ShowResultsCanvas.gameObject.SetActive(false);
        WictoryScreenCanvas.gameObject.SetActive(true);

        winerPlayerView.SetPlayer(winer);
    }

}
