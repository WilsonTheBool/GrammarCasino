using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Text playerMoney;

    [SerializeField]
    private Text playerName;

    [SerializeField]
    private Image playerIcon;

    [SerializeField]
    private Image playerCrown;

    [SerializeField]
    private Image playerRedX;

    [SerializeField]
    private  Player player;

    [SerializeField]
    private Text eleminatedText;

    public Player Player
    {
        private set
        {
            player = value;
        }

        get
        {
            return player;
        }
    }

    public Vector2 sizeSmall;
    public Vector2 sizeNormal;

    //Будем исходить из того что иконки  и имена игроков не меняются во время матча
    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
        playerIcon.sprite = player.playerIcon;
        playerName.text = player.playerName;
        UpdateUI();
    }
    [SerializeField]
    Text moneyText;

    public void AddMoney(int count)
    {
        moneyText.text = "+" + count.ToString();
        moneyText.color = Color.green;

        if (player != null)
            player.money += count;

        UpdateUI();

        StartCoroutine(MoneyChange());
    }

    public void RemoveMoney(int count)
    {
        moneyText.text = "-" + count.ToString();
        moneyText.color = Color.red;

        if (player != null)
            player.money -= count;

        UpdateUI();

        StartCoroutine(MoneyChange());
    }

    private IEnumerator MoneyChange()
    {
        moneyText.CrossFadeAlpha(1, 0.3f, true);

        yield return new WaitForSeconds(3);

        moneyText.CrossFadeAlpha(0, 1, true);
    }

    private void Start()
    {
        if(player != null)
        {
            SetPlayer(player);
        }
    }

    //обновить изменяемые параметры игроков
    public void UpdateUI()
    {
        if (isActiveAndEnabled)
        {
            if (player != null)
            {
                //update money
                playerMoney.text = player.money.ToString("F0");

                if (player.money < 0)
                {
                    playerMoney.color = Color.red;
                }
                else
                {
                    playerMoney.color = Color.white;
                }

                //update lead player
                if (player.isLeading && !playerCrown.IsActive())
                {
                    playerCrown.gameObject.SetActive(true);
                }

                if (!player.isLeading && playerCrown.IsActive())
                {
                    playerCrown.gameObject.SetActive(false);
                }

                //update inactive player
                if (!player.isPlayerActive && !playerRedX.IsActive())
                {
                    playerRedX.gameObject.SetActive(true);
                    eleminatedText.gameObject.SetActive(true);
                }

                if (player.isPlayerActive && playerRedX.IsActive())
                {
                    playerRedX.gameObject.SetActive(false);
                    eleminatedText.gameObject.SetActive(false);
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
        
    }
}
