using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWindowBehaviour : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text questionText;

    [SerializeField]
    private UnityEngine.UI.Text taskText;

    public void OpenWindow()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }

    public void SetQuestion(string text)
    {
        questionText.text = text;
    }

    public void SetText(string text)
    {
        taskText.text = text;
    }
}
