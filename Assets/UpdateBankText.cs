using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBankText : MonoBehaviour
{
    [SerializeField]
    GameController game;

    [SerializeField]
    UnityEngine.UI.Text text;

    private void FixedUpdate()
    {
        text.text = game.bank.ToString();
    }
}
