using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerIconClickable : MonoBehaviour, IPointerClickHandler
{
    PlayerCreateHolder controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.SwitchIconWindow();
    }

    private void Start()
    {
        controller = GetComponentInParent<PlayerCreateHolder>();
    }
}
