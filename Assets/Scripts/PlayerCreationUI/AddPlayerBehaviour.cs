using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject playerCreatePrefab;

    [SerializeField]
    int maxPlayerCount = 7;

    int count = 1;
    public void AddNewPlayer()
    {
        if(count < maxPlayerCount)
        {
            Transform parent = transform.parent;

            transform.parent = null;

            Instantiate(playerCreatePrefab, parent);

            transform.parent = parent;

            count++;
        }

        if (count == maxPlayerCount)
        {
            gameObject.SetActive(false);
        }


    }
}
