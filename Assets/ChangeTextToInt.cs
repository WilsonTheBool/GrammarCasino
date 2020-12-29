using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextToInt : MonoBehaviour
{
    private Text text;

    [SerializeField]
    private int mult;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void ChangeText(System.Single value)
    {
        text.text = (mult * value).ToString();
    }
}
