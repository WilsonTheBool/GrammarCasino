using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayersController : MonoBehaviour
{
    [SerializeField]
    private PlayerIconWindow iconWindow;

    [SerializeField]
    Vector3 iconWindowOffset;

    private PlayerCreateHolder lastCaller;

    private void Start()
    {
        iconWindow.IconSelected += IconWindow_IconSelected;
    }

    private void IconWindow_IconSelected(Sprite obj)
    {
        lastCaller.SetIcon(obj);
    }

    public void SwitchIconWindow(PlayerCreateHolder holder)
    {
        if(holder != lastCaller)
        {
            iconWindow.gameObject.SetActive(true);
            iconWindow.transform.position = holder.transform.position + iconWindowOffset;
        }
        else
        {
            if (iconWindow.gameObject.activeSelf)
            {
                iconWindow.gameObject.SetActive(false);
            }
            else
            {
                iconWindow.gameObject.SetActive(true);
                iconWindow.transform.position = holder.transform.position + iconWindowOffset;
            }
        }
        

        lastCaller = holder;
    }
}
