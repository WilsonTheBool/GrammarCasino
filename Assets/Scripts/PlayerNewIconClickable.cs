using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerNewIconClickable : MonoBehaviour, IPointerClickHandler
{
    PlayerIconWindow controller;
    Sprite sprite;

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.SelectIcon(sprite);
    }

    private void Start()
    {
        controller = GetComponentInParent<PlayerIconWindow>();
        sprite = GetComponent<Image>().sprite;
    }
}
