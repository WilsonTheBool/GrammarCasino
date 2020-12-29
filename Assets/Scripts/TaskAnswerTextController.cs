using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskAnswerTextController : MonoBehaviour
{ 

    [SerializeField]
    private Text text;

    [SerializeField]
    private Text groupText;

    public void SetNewText(TaskBase task)
    {
        text.text = task.answer;

        text.text += "\n\n" + task.explanation;

        groupText.text = task.group;
    }
}
