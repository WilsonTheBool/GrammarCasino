using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconWindow : MonoBehaviour
{
    public event Action<Sprite> IconSelected;

    public void SelectIcon(Sprite icon)
    {
        IconSelected?.Invoke(icon);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
