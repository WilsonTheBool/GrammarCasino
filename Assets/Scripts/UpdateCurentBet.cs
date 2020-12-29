using UnityEngine;
using System.Collections;

public class UpdateCurentBet : MonoBehaviour
{
    [SerializeField]
    GameController game;

    [SerializeField]
    UnityEngine.UI.Text text;

    private void FixedUpdate()
    {
        text.text = game.minBet.ToString();
    }
}
