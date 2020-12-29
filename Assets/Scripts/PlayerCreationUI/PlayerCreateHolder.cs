using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreateHolder : MonoBehaviour
{
    
    private CreatePlayersController controller;

    [SerializeField]
    public PlayerIconClickable icon;

    [SerializeField]
    public Text PName;

    [SerializeField]
    public bool isLead;

    public void GetPlayer(ref Player p)
    {
        p.isLeading = isLead;
        p.playerName = PName.text;
        p.playerIcon = icon.GetComponent<Image>().sprite;
    }

    public void SetIcon(Sprite sprite)
    {
        icon.GetComponent<Image>().sprite = sprite;
        SwitchIconWindow();
    }

    private void Start()
    {
        controller = GetComponentInParent<CreatePlayersController>();
    }

    public void SwitchIconWindow()
    {
        controller.SwitchIconWindow(this);
    }
}
