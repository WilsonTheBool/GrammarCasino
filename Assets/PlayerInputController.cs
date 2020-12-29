using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    PlayerView curentPlayerView;

    public UnityAction<bool> OnTrueFalseButtonPress;

    public UnityAction<int> OnNumberButtonPress;

    List<Button> allInputButtons;

    public Button[] TrueFalseButtons; 
    public Button[] TestButtons; 

    private void Start()
    {
        allInputButtons = new List<Button>();
        allInputButtons.AddRange(TrueFalseButtons);
        allInputButtons.AddRange(TestButtons);
    }

    public void HideButtons()
    {
        foreach(Button button in allInputButtons)
        {
            if (button.gameObject.activeSelf)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    public void ShowTrueFalseButtons()
    {
        foreach(Button b in TrueFalseButtons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ShowTestButtons()
    {
        foreach (Button b in TestButtons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void OnNumberButtonPressed(int buttonNumber)
    {
        OnNumberButtonPress?.Invoke(buttonNumber);
    }

    public void OnIsCorrectButtonPressed(bool isCorrect)
    {
        OnTrueFalseButtonPress?.Invoke(isCorrect);
    }

    public PlayerView GetCurentPlayer()
    {
        return curentPlayerView;
    }
}
